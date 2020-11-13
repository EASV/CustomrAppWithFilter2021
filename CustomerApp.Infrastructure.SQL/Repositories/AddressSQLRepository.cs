using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQL.Repositories
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
            return _ctx.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public Address Create(Address address)
        {
            //_ctx.DetachAll();
            
            //_ctx.Attach(address.City).State = EntityState.Unchanged;
            var addressEntry = _ctx.Add(address);
            _ctx.SaveChanges();
            return addressEntry.Entity;
        }

        public List<Address> ReadAll()
        {
            return _ctx.Addresses.ToList();
        }
    }
}