using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IAddressRepository
    {
        public Address ReadById(int id);
    }
}