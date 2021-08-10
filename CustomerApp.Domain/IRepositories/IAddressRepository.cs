using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.Domain.IRepositories
{
    public interface IAddressRepository
    {
        public Address ReadById(int id);
        public Address Create(Address address);

        List<Address> ReadAll();
        Address Update(Address address);
    }
}