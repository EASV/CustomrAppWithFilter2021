using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
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
            filteredList.List = _ctx.Customers.ToList();
            return filteredList;
        }
        
        
        public Customer ReadyById(int id)
        {
            return _ctx.Customers
                .Include(c => c.Address)
                .ThenInclude(a => a.City)
                .FirstOrDefault(c => c.Id == id);
        }
        
        public Customer Create(Customer customer)
        {
            //_ctx.Attach(customer.Address).State = EntityState.Unchanged;
            var customerEntry = _ctx.Add(customer);
            _ctx.SaveChanges();
            return customerEntry.Entity;
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