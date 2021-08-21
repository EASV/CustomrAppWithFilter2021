using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Core.IServices
{
    public interface ICountryService
    {
        List<Country> ReadAll();
        Country Create(Country country);
    }
}