using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.IRepositories
{
    public interface IAddressRepository
    {
        public Address ReadById(int id);
        public Address Create(Address address);

        List<Address> ReadAll();
        Address Update(Address address);
    }
}