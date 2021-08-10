using System.Collections.Generic;
using CustomerApp.Core.IServices;
using CustomerApp.Core.Models;
using CustomerApp.Domain.IRepositories;

namespace CustomerApp.Domain.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public List<Country> ReadAll()
        {
            return _countryRepository.GetAll();
        }

        public Country Create(Country country)
        {
            return _countryRepository.Create(country);
        }
    }
}