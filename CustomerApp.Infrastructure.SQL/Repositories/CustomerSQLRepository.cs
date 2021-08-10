using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.Filter;
using CustomerApp.Core.Models;
using CustomerApp.Domain.IRepositories;
using CustomerApp.Infrastructure.SQL.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class CustomerSQLRepository: ICustomerRepository
    {
        private readonly CustomerAppDBContext _ctx;

        public CustomerSQLRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public FilteredList<Customer> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Customer>();

            filteredList.TotalCount = _ctx.Customers.Count();
            filteredList.FilterUsed = filter;
            filteredList.List = 
                _ctx.Customers.Select(c => new Customer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address == null ? null : new Address
                    {
                        Id = c.Address.Id,
                        Additional = c.Address.Additional,
                        StreetName = c.Address.StreetName,
                        StreetNr = c.Address.StreetNr
                    }
                }).ToList();
            return filteredList;
        }
        
        
        public Customer ReadyById(int id)
        {
            return _ctx.Customers
                .Include(c => c.Address)
                .ThenInclude(a => a.City)
                .Select(c => new Customer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address == null ? null : new Address
                    {
                        Id = c.Address.Id,
                        Additional = c.Address.Additional,
                        StreetName = c.Address.StreetName,
                        StreetNr = c.Address.StreetNr
                    }
                })
                .FirstOrDefault(c => c.Id == id);
        }
        
        public Customer Create(Customer customer)
        {
            //_ctx.Attach(customer.Address).State = EntityState.Unchanged;
            var customerEntity = new CustomerSql
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                AddressId = customer.Address.Id
            };
            
            var customerEntry = _ctx.Add(customerEntity);
            _ctx.SaveChanges();
            return new Customer
            {
                Id = customerEntry.Entity.Id,
                LastName = customerEntry.Entity.LastName,
                FirstName = customerEntry.Entity.FirstName,
                Address = new Address
                {
                    Id = customerEntry.Entity.Address.Id,
                     StreetName = customerEntry.Entity.Address.StreetName
                }
            };
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerEntry = _ctx.Update(customerUpdate);
            _ctx.SaveChanges();
            return customerEntry.Entity;
        }

        public Customer Delete(int id)
        {
            var customerEntry = _ctx.Remove(new Customer(){Id = id});
            _ctx.SaveChanges();
            return customerEntry.Entity;
        }

        public List<Customer> Filter(string orderDir)
        {
            throw new System.NotImplementedException();
        }
    }
}