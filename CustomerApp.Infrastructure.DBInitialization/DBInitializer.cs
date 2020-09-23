using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;

        public DBInitializer(
                 ICityRepository cityRepository, 
                 ICustomerRepository customerRepository,
                 IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
        }

        public void InitData()
        {
            City city = _cityRepository.Create(new City()
            {
                ZipCode = 6000,
                Name = "Kolding"
            });
            var address = new Address
            {
                Id = 1,
                Street = "Øffgade 7",
                Customers = new List<Customer>(),
                City = city
            };
            _addressRepository.Create(address);
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

        }
    }
}