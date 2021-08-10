using System.Collections.Generic;
using CustomerApp.Core.IServices;
using CustomerApp.Core.Models;
using CustomerApp.Core.Persistance.Interfaces;

namespace CustomerApp.Core.Domain.Services
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
    }
}