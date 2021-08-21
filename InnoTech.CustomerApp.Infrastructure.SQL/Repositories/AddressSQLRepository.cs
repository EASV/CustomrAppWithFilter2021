using System.Collections.Generic;
using System.Linq;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;
using InnoTech.CustomerApp.Infrastructure.SQL.DBEntities;

namespace InnoTech.CustomerApp.Infrastructure.SQL.Repositories
{
    public class AddressSQLRepository: IAddressRepository
    {
        private readonly CustomerAppDBContext _ctx;

        public AddressSQLRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public Address ReadById(int id)
        {
            return _ctx.Addresses
                .Select(a => new Address()
                {
                    Additional = a.Additional,
                    Id = a.Id,
                    StreetNr = a.StreetNr,
                    StreetName = a.StreetName,
                    City = a.City == null ? null : new City
                    {
                        Name = a.City.Name,
                        ZipCode = a.City.ZipCode
                    },
                    Customers = a.Customers == null ? null : 
                        a.Customers.Select(c => new Customer
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Id = c.Id
                        }).ToList()
                })
                .FirstOrDefault(a => a.Id == id);
        }

        public Address Create(Address address)
        {
            //_ctx.DetachAll();
            
            //_ctx.Attach(address.City).State = EntityState.Unchanged;
            var addressEntry = _ctx.Add(new AddressSql
            {
                Id = address.Id,
                Additional = address.Additional,
                CityId = address.City?.ZipCode ?? 0,
                StreetName = address.StreetName,
                StreetNr = address.StreetNr
            });
            _ctx.SaveChanges();
            return new Address()
            {
                Id = addressEntry.Entity.Id,
                Additional = addressEntry.Entity.Additional,
                City = new City()
                {
                    ZipCode = addressEntry.Entity.CityId
                },
                StreetName = addressEntry.Entity.StreetName,
                StreetNr = addressEntry.Entity.StreetNr
            };
        }

        public List<Address> ReadAll()
        {
            return new List<Address>();
            // return _ctx.Addresses.ToList();
        }

        public Address Update(Address address)
        {
            var entry = _ctx.Update(address);
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}