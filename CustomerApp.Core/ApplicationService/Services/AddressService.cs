using System.Collections.Generic;
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
            if (address.City != null)
            {
                var city = _cityRepository.ReadById(address.City.ZipCode);
                if (city == null)
                {
                    throw new InvalidDataException("City åhåhåhå");
                }
            }
            return _addressRepository.Create(address);
        }

        public List<Address> GetAll()
        {
            return _addressRepository.ReadAll();
        }
    }
}