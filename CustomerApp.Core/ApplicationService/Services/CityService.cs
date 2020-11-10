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
        private readonly ICityValidator _validator;

        public CityService(
            ICityValidator validator, 
            ICityRepository cityRepository)
        {
            _validator = validator ?? throw new NullReferenceException("Validator Cannot be Null");
            _cityRepository = cityRepository ?? throw new NullReferenceException("CityRepository Cannot be Null");
        }
        
        public List<City> ReadAll()
        {
            return _cityRepository.GetAll();
        }

        public City Create(City city)
        {
            _validator.DefaultValidation(city);
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