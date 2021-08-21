using System.Collections.Generic;
using InnoTech.CustomerApp.Core.IServices;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;

namespace InnoTech.CustomerApp.Domain.Services
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