using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICityService
    {
        public List<City> ReadAll();
        City Create(City city);
        City FindCityByZipcode(int zipCode);
        City Delete(int zipCode);
    }
}