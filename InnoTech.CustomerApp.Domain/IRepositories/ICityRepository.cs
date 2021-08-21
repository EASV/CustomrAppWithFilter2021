using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.IRepositories
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