using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.SQL.Data.Repositories
{
    public class AddressSQLRepository: IAddressRepository
    {
        private CustomerAppContext _ctx;

        public AddressSQLRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public Address Create(Address address)
        {
            var addressCreated = _ctx.Addresses.Add(address);
            _ctx.SaveChanges();
            return addressCreated.Entity;
        }
        
        public Address ReadById(int id)
        {
            return _ctx.Addresses
                .FirstOrDefault(c => c.Id == id);
        }
    }
}