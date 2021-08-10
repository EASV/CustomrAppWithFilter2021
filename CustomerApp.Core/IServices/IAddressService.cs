using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.IServices
{
    public interface IAddressService
    {
        Address Create(Address address);
        
        List<Address> GetAll();

        Address GetById(int id);
        Address Update(Address address);
    }
}