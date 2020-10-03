using System.Collections.Generic;
using System.Linq;
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
            return _ctx.Cities.ToList();
        }

        public City Create(City city)
        {
            var cityEntry = _ctx.Add(city);
            _ctx.SaveChanges();
            return cityEntry.Entity;
        }
        
        public void CreateAll(List<City> cities)
        {
            _ctx.AddRange(cities);
            _ctx.SaveChanges();
        }

        public City ReadById(int cityZipCode)
        {
            return _ctx.Cities
                .AsNoTracking()
                .FirstOrDefault(city => city.ZipCode == cityZipCode);
        }
    }
}