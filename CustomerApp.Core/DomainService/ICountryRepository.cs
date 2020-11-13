using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country Create(Country country);
    }
}