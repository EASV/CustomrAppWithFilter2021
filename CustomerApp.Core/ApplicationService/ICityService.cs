using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICityService
    {
        public FilteredList<City> ReadAll(Filter filter = null);
        City Create(City city);
        City FindCityByZipcode(int zipCode);
        City Delete(int zipCode);
        City Update(City city);
    }
}