using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Core.IServices
{
    public interface ICityService
    {
        public List<City> ReadAll();
        City Create(City city);
        City FindCityByZipcode(int zipCode);
        City Delete(int zipCode);
        City Update(City city);
    }
}