using System;
using System.Collections.Generic;
using InnoTech.CustomerApp.Core.IServices;
using InnoTech.CustomerApp.Core.IValidators;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;

namespace InnoTech.CustomerApp.Domain.Services
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
            _addressValidator.DefaultValidation(address);
            return _addressRepository.Create(address);
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
           return _addressRepository.Update(address);
        }
    }
}