using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IAddressRepository
    {
        public Address ReadById(int id);
        public Address Create(Address address);

        List<Address> ReadAll();
    }
}