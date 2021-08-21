using System;
using InnoTech.CustomerApp.Core.Filter;
using InnoTech.CustomerApp.Core.IServices;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.IRepositories;
using InnoTech.CustomerApp.Domain.Validators;

namespace InnoTech.CustomerApp.Domain.Services
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

        
        public FilteredList<Customer> GetAllCustomers(InnoTech.CustomerApp.Core.Filter.Filter filter)
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
