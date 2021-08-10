using System;
using CustomerApp.Core.Domain.Validators;
using CustomerApp.Core.Filter;
using CustomerApp.Core.IServices;
using CustomerApp.Core.Models;
using CustomerApp.Core.Persistance.Interfaces;

namespace CustomerApp.Core.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        readonly ICustomerRepository _customerRepo;
        private IAddressRepository _addressRepository;

        public CustomerService(ICustomerRepository customerRepository,
             IAddressRepository addressRepository)
        {
            _customerRepo = customerRepository;
            _addressRepository = addressRepository;
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

        
        public FilteredList<Customer> GetAllCustomers(Filter.Filter filter)
        {
            if (filter == null)
            {
                throw new NullReferenceException("Filter must exist");
            }
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "FirstName";
            }

            if (filter.Price > 0 && filter.Price > 100000000) 
            {
                
            }
            return _customerRepo.ReadAll(filter);
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            return _customerRepo.Update(customerUpdate);
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }
    }
}
