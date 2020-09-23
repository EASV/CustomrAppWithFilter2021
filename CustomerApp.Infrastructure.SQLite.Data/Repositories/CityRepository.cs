using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQLite.Data.Repositories
{
    public class CityRepository: ICityRepository
    {
        private readonly CustomerAppLiteContext _ctx;

        public CityRepository(CustomerAppLiteContext ctx)
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

        public City ReadById(int cityZipCode)
        {
            return _ctx.Cities
                .AsNoTracking()
                .FirstOrDefault(c => c.ZipCode == cityZipCode);
        }
    }
}