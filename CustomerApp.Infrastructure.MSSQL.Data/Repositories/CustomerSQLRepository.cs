using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.MSSQL.Data.Repositories
{
    public class CustomerSQLRepository: ICustomerRepository
    {
        private CustomerAppContext _ctx;

        public CustomerSQLRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;
        }
        public Customer Create(Customer customer)
        {
            var customerCreated = _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
            return customerCreated.Entity;
        }

        public Customer ReadyById(int id)
        {
            return _ctx.Customers.FirstOrDefault(c => c.Id == id);
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            var filteredlist = new FilteredList<Customer>();
            filteredlist.TotalCount = _ctx.Customers.Count();
            filteredlist.List = _ctx.Customers
                .Include(c => c.Address)
                .ToList();
            return filteredlist;
        }

        public Customer Update(Customer customerUpdate)
        {
           var updatedEntity = _ctx.Customers.Update(customerUpdate);
           _ctx.SaveChanges();
           return updatedEntity.Entity;
        }

        public Customer Delete(int id)
        {
            var customerDelete = ReadyById(id);
            _ctx.Customers.Remove(ReadyById(id));
            _ctx.SaveChanges();
            return customerDelete;
        }

        public List<Customer> Filter(string orderDir)
        {
            return "ASC".Equals(orderDir)
                ? _ctx.Customers.OrderBy(c => c.FirstName).ToList()
                : _ctx.Customers.OrderByDescending(c => c.FirstName).ToList();
        }
    }
}