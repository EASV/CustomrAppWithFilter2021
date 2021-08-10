using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.Domain.IRepositories
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country Create(Country country);
    }
}