using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomerApp.Core.ApplicationService.Validators;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerService: ICustomerService
    {
        readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }

        public Customer NewCustomer(string firstName, string lastName, Address address)
        {
            var cust = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            return cust;
        }


        public Customer CreateCustomer(Customer cust)
        {
            new CustomerValidator().Validate(cust);
            return _customerRepo.Create(cust);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadyById(id);
        }

        
        public FilteredList<Customer> GetAllCustomers(Filter filter)
        {
            if (filter == null)
            {
                throw new NullReferenceException("Filter must exist");
            }
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "FirstName";
            }
            return _customerRepo.ReadAll(filter);
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customer = FindCustomerById(customerUpdate.Id);
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.Address = customerUpdate.Address;
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }
    }
}
