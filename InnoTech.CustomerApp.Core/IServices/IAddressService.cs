using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Core.IServices
{
    public interface IAddressService
    {
        Address Create(Address address);
        
        List<Address> GetAll();

        Address GetById(int id);
        Address Update(Address address);
    }
}