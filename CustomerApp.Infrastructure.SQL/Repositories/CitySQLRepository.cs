using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.ApplicationService.Exceptions;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class CitySQLRepository: ICityRepository
    {
        private readonly CustomerAppDBContext _ctx;

        public CitySQLRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        public List<City> GetAll()
        {
            return _ctx.Cities
                .Include(c => c.Country)
                .Select(c => new City(){
                     ZipCode = c.ZipCode,
                     Country = new Country()
                     {
                         Name = c.Country != null ?  c.Country.Name : ""
                     },
                     CountryId = c.CountryId,
                     Name = c.Name
                })
                .ToList();
        }

        public City Create(City city)
        {
            /*var cityEntry = _ctx.Add(city);
            _ctx.SaveChanges();
            return cityEntry.Entity;
            */
            try
            {
                var cityEntry = _ctx.Add(city);
                _ctx.SaveChanges();
                return cityEntry.Entity;
            }
            catch (Exception e)
            {
                throw new DataSourceException(e.InnerException.Message);
            }
            
        }
        
        public void CreateAll(List<City> cities)
        {
            _ctx.AddRange(cities);
            _ctx.SaveChanges();
        }

        public City ReadById(int cityZipCode)
        {
            return _ctx.Cities
                .Include(c => c.Tourists)
                .ThenInclude(ct => ct.Tourist)
                .AsNoTracking()
                .FirstOrDefault(city => city.ZipCode == cityZipCode);
        }

        public City Delete(int zipCode)
        {
            //      var city = _ctx.Cities.FirstOrDefault(c => c.ZipCode == zipCode);
            /*var entry = _ctx.Cities.Attach(new City() {ZipCode = zipCode});
            entry.State = EntityState.Deleted;
            
            //_ctx.RemoveRange(_ctx.Cities.Where(c => c.ZipCode == zipCode));
            /*var cityToDelete = ReadById(zipCode);
            var entry = _ctx.Remove(cityToDelete);
           */
            //var entry =_ctx.Remove(_ctx.Cities.Single(a => a.ZipCode == zipCode));
            var entry = _ctx.Remove(new City(){ZipCode = zipCode});
            _ctx.SaveChanges();
            //return entry.Entity;
             return entry.Entity;
            // return null;
        }

        public City Update(City cityToUpdate)
        {
            var entry = _ctx.Update(cityToUpdate);
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}