using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICityRepository
    {
        public List<City> GetAll();
        public City Create(City city);
        public void CreateAll(List<City> cities);
        public City ReadById(int cityZipCode);
        public City Delete(int zipCode);
        City Update(City cityToUpdate);
    }
}