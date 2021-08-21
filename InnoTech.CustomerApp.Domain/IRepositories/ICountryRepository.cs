using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.IRepositories
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country Create(Country country);
    }
}