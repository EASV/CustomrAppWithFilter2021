using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private CustomerAppDBContext _ctx;

        public CountryRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        public List<Country> GetAll()
        {
            return _ctx.Countries.ToList();
        }

        public Country Create(Country country)
        {
            var entry = _ctx.Countries.Add(country);
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}