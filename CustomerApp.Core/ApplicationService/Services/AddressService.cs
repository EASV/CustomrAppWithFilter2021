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
        private IAddressValidator _addressValidator;

        public AddressService(
            IAddressValidator addressValidator,
            IAddressRepository addressRepository)
        {
            _addressValidator = addressValidator ?? throw new NullReferenceException("Validator cannot be null");
            _addressRepository = addressRepository ?? throw new NullReferenceException("Repository cannot be null");
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

        public Address Update(Address address)
        {
            _addressValidator.DefaultValidation(address);
            
            return null;
        }
    }
}