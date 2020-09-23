using System.Collections.Generic;
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
    }
}