using System.Collections.Generic;
using System.Linq;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;
using InnoTech.CustomerApp.Infrastructure.SQL.DBEntities;

namespace InnoTech.CustomerApp.Infrastructure.SQL.Repositories
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
            return _ctx.Countries.Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public Country Create(Country country)
        {
            var entry = _ctx.Countries.Add(new CountrySql
            {
                Id = country.Id,
                Name = country.Name
            });
            _ctx.SaveChanges();
            return new Country
            {
                Id = entry.Entity.Id,
                Name = entry.Entity.Name
            };
        }
    }
}