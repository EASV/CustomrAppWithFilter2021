using System;
using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.SQL;

namespace CustomerApp.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IHatRepository _hatRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly CustomerAppDBContext _ctx;

        public DBInitializer(
                 CustomerAppDBContext ctx,
                 IHatRepository hatRepository,
                 ICityRepository cityRepository, 
                 ICustomerRepository customerRepository,
                 IAddressRepository addressRepository,
                 ICountryRepository countryRepository)
        {
            _ctx = ctx;
            _hatRepository = hatRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public void InitData()
        {
            Country country = _countryRepository.Create(new Country() {Name = "Denmark"});
            _countryRepository.Create(new Country() {Name = "Sweden"});
            _countryRepository.Create(new Country() {Name = "Norway"});
            var listCities = new List<City>();
            for (int i = 0; i < 1000; i++)
            {
                listCities.Add(new City()
                {
                    ZipCode = 6001 + i,
                    Name = "osteBy" + i,
                    CountryId = country.Id
                });
            }
            _cityRepository.CreateAll(listCities);

            var tourist1 = _ctx.Tourists.Add(new Tourist() {Name = "John"}).Entity;
            var tourist2 = _ctx.Tourists.Add(new Tourist() {Name = "Bill"}).Entity;
            var tourist3 = _ctx.Tourists.Add(new Tourist() {Name = "Bob"}).Entity;
            var tourist4 = _ctx.Tourists.Add(new Tourist() {Name = "Allan"}).Entity;
            _ctx.SaveChanges();
            
            _ctx.CityTourists.Add(new CityTourist() {CityId = listCities[0].ZipCode, TouristId = tourist1.Id, VisitDate = DateTime.Now});
            _ctx.CityTourists.Add(new CityTourist() {CityId = listCities[0].ZipCode, TouristId = tourist2.Id, VisitDate = DateTime.Now.AddYears(-3)});
            //_ctx.CityTourists.Add(new CityTourist() {CityId = listCities[2].ZipCode, TouristId = tourist1.Id});
            //_ctx.CityTourists.Add(new CityTourist() {CityId = listCities[1].ZipCode, TouristId = tourist2.Id});
            _ctx.SaveChanges();
            
            var address = new Address
            {
                Id = 1,
                StreetName = "Øffgade",
                StreetNr = 7,
                Additional = "TTL",
                Customers = new List<Customer>(),
                CityId = 6001
            };
            _addressRepository.Create(address);
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