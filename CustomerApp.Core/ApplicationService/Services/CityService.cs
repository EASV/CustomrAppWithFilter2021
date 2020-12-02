using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.ApplicationService.Exceptions;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CityService: ICityService
    {
        private readonly ICityValidator _cityValidator;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(
            ICityValidator cityValidator,
            IUnitOfWork unitOfWork)
        {
            _cityValidator = cityValidator ?? throw new NullReferenceException("Validator Cannot be null");
            _unitOfWork = unitOfWork;
        }
        
        public FilteredList<City> ReadAll(Filter filter = null)
        {
            if (filter == null)
            {
                filter = new Filter(){CurrentPage = 1, ItemsPrPage = 5};
            }
            return _unitOfWork.CityRepository().GetAll(filter);
        }

        public City Create(City city)
        {
            _cityValidator.DefaultValidation(city);
            var cityAfter = _unitOfWork.CityRepository().Create(city);
            _unitOfWork.SaveChanges();
            return cityAfter;
        }

        public City FindCityByZipcode(int zipCode)
        {
            return _unitOfWork.CityRepository().ReadById(zipCode);
        }

        public City Delete(int zipCode)
        {
                var city = _unitOfWork.CityRepository().ReadById(zipCode);
                if (city == null)
                {
                    throw new Exception("City not found.. WRAAAAHHHHHHH!!!! ");
                }
                var cityAfter = _unitOfWork.CityRepository().Delete(zipCode);
                _unitOfWork.SaveChanges();

                return cityAfter;
            
        }

        public City Update(City city)
        {
            try
            {
                _cityValidator.DefaultValidation(city);
                var cityAfter = _unitOfWork.CityRepository().Update(city);
                _unitOfWork.SaveChanges();
                return cityAfter;
            }
            catch (DataSourceException ds)
            {
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}