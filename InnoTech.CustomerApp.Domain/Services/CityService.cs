using System;
using System.Collections.Generic;
using InnoTech.CustomerApp.Core.IServices;
using InnoTech.CustomerApp.Core.IValidators;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;

namespace InnoTech.CustomerApp.Domain.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICityValidator _cityValidator;
        
        public CityService(
            ICityValidator cityValidator,
            ICityRepository cityRepository)
        {
            _cityValidator = cityValidator ?? throw new NullReferenceException("Validator Cannot be null");
            _cityRepository = cityRepository ?? throw new NullReferenceException("CityRepository Cannot be Null");
        }
        
        public List<City> ReadAll()
        {
           
            return _cityRepository.GetAll();
        }

        public City Create(City city)
        {
            _cityValidator.DefaultValidation(city);
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

        public City Update(City city)
        {
            _cityValidator.DefaultValidation(city);
            return _cityRepository.Update(city);
            /*try
            {
                
            }
            catch (DataSourceException ds)
            {
    
            }
            catch (Exception e)
            {
                
            }*/
        }
    }
}