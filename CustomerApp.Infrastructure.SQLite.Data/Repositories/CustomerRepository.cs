using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQLite.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerAppLiteContext _ctx;

        public CustomerRepository(CustomerAppLiteContext ctx)
        {
            _ctx = ctx;
        }
        
        public Customer Create(Customer customer)
        {
            if (customer.Address != null)
            {
                _ctx.Attach(customer.Address).State = EntityState.Unchanged;
            }
            var customerEntry = _ctx.Add(customer);
            _ctx.SaveChanges();
            return customerEntry.Entity;
        }

        public Customer ReadyById(int id)
        {
            return _ctx.Customers
                .AsNoTracking()
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Customer>();
            filteredList.TotalCount = _ctx.Customers.Count();
            filteredList.FilterUsed = filter;
            filteredList.List = _ctx.Customers.ToList();
            return filteredList;
        }

        public Customer Update(Customer customerUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> Filter(string orderDir)
        {
            throw new System.NotImplementedException();
        }
    }
}