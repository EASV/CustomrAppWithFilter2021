using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(
            IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public Address Create(Address address)
        {
            try
            {
                return _addressRepository.Create(address);
            }
            catch (Exception e)
            {
                throw  new Exception(e.Message);
            }
           
        }

        public List<Address> GetAll()
        {
            return _addressRepository.ReadAll();
        }

        public Address GetById(int id)
        {
            return _addressRepository.ReadById(id);
        }
    }
}