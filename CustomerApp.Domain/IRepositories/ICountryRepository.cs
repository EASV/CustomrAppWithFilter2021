using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.Persistance.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country Create(Country country);
    }
}