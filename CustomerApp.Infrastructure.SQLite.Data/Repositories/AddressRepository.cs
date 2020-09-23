using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQLite.Data.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly CustomerAppLiteContext _ctx;

        public AddressRepository(CustomerAppLiteContext ctx )
        {
            _ctx = ctx;
        }
        public Address ReadById(int id)
        {
            return _ctx.Addresses
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
        }

        public Address Create(Address address)
        {
            var addressEntry = _ctx.Add(address);
            _ctx.SaveChanges();
            return addressEntry.Entity;
        }
    }
}