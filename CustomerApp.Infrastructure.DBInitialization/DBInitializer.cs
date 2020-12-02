using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.SQL;

namespace CustomerApp.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly IUnitOfWork _uow;

        public DBInitializer(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void InitData()
        {
            var country = _uow.CountryRepository().Create(new Country() {Name = "Denmark"});
            _uow.CountryRepository().Create(new Country() {Name = "Sweden"});
            _uow.CountryRepository().Create(new Country() {Name = "Norway"});
            for (int i = 0; i < 10; i++)
            {
                _uow.CityRepository().Create(new City()
                {
                    ZipCode = 6001 + i,
                    Name = $"osteBy {i}",
                    Country = country
                });
            }
            _uow.SaveChanges();
            //_ctx.CityTourists.Add(new CityTourist() {CityId = listCities[2].ZipCode, TouristId = tourist1.Id});
            //_ctx.CityTourists.Add(new CityTourist() {CityId = listCities[1].ZipCode, TouristId = tourist2.Id});
            /*
            Customer cust;
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "John",
                    LastName = "Bilsson"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Bill",
                    LastName = "Bilbo"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Bob",
                    LastName = "Snurfheit the 3rd"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Little",
                    LastName = "John"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Zilbo",
                    LastName = "Zaggins"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
               cust = new Customer()
                {
                    Address = address,
                    FirstName = "Aykoniksotytytjiiimsi",
                    LastName = "OST"
                });
            address.Customers.Add(cust);
*/
        }
    }
}