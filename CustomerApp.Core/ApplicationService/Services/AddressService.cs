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
        private ICityRepository _cityRepository;

        public AddressService(IAddressRepository addressRepository,
            ICityRepository cityRepository)
        {
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
        }
        public Address Create(Address address)
        {
            try
            {
                return _addressRepository.Create(address);
            }
            catch (Exception e)
            {
                throw  new Exception("Something went wrong in DB");
            }
           
        }

        public List<Address> GetAll()
        {
            return _addressRepository.ReadAll();
        }
    }
}