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
        public FilteredList<City> GetAll(Filter filter = null)
        {   
            var newList = new FilteredList<City>();
            newList.FilterUsed = filter;
            newList.TotalCount = _ctx.Cities.Count();

            IQueryable<City> listFilter = _ctx.Cities
                .Include(c => c.Tourists)
                .ThenInclude(ct => ct.Tourist)
                .Include(c => c.Country);
            if (filter?.SearchField != null && filter.SearchField.Length > 0 && filter?.SearchText != null && filter.SearchText.Length > 0)
            {
                if (filter.SearchField.Equals("Name"))
                {
                    listFilter = listFilter.Where(c => c.Name.Contains(filter.SearchText));
                    newList.TotalCount = _ctx.Cities.Count(c => c.Name.Contains(filter.SearchText));

                }
            }
            if (filter != null && filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                listFilter = listFilter.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }
            newList.List = listFilter.ToList();

            return newList;
        }

        public City Create(City city)
        {
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
            // 1: Get rid of all current rows with CityId 7002
            _ctx.CityTourists.RemoveRange(_ctx.CityTourists.Where(ct => ct.CityId == zipCode));
            var entry = _ctx.Remove(new City(){ZipCode = zipCode});
            _ctx.SaveChanges();
            //return entry.Entity;
             return entry.Entity;
            // return null;
        }

        public City Update(City cityToUpdate)
        {
            // 1: Get rid of all current rows with CityId 7002
            _ctx.CityTourists.RemoveRange(_ctx.CityTourists.Where(ct => ct.CityId == cityToUpdate.ZipCode));
            // 2: Adding All new Relations to CityTourist
            _ctx.CityTourists.AddRange(cityToUpdate.Tourists);
            // 3: Saving updates
            var entry = _ctx.Update(cityToUpdate);
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}