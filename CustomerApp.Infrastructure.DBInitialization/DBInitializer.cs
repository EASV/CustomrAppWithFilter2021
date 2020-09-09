using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly ICustomerRepository _customerRepository;

        public DBInitializer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void InitData()
        {
            var address = new Address
            {
                Id = 1,
                Street = "Øffgade 7",
                Customers = new List<Customer>()
            };
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