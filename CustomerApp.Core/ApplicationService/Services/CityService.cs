using System;
using System.Collections.Generic;
using CustomerApp.Core.ApplicationService.Exceptions;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        
        public List<City> ReadAll()
        {
            return _cityRepository.GetAll();
        }

        public City Create(City city)
        {
            if (string.IsNullOrEmpty(city.Name) || city.ZipCode <= 0)
            {
                throw new ArgumentException("Name must be available and Zipcode must be above 0");
            }

            if (city.ZipCode < 1000 || city.ZipCode > 9999)
            {
                throw new ArgumentException("Danish Zipcode must be between 1000 and 9999");
            }
            if (city.Name.Length < 2 || city.Name.Length > 30)
            {
                throw new ArgumentException("City name must be between 2 and 30 characters");
            }
            return _cityRepository.Create(city);
        }

        public City FindCityByZipcode(int zipCode)
        {
            return _cityRepository.ReadById(zipCode);
        }

        public City Delete(int zipCode)
        {
                var city = _cityRepository.ReadById(zipCode);
                if (city == null)
                {
                    throw new Exception("City not found.. WRAAAAHHHHHHH!!!! ");
                }
                return _cityRepository.Delete(zipCode);
            
        }
    }
}