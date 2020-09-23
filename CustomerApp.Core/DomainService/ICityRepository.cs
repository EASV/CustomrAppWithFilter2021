using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICityRepository
    {
        public List<City> GetAll();
        public City Create(City city);
    }
}