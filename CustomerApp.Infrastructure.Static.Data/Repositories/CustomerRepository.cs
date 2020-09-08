using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {   
        static int id = 1;
        private static List<Customer> _customers = new List<Customer>();

        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);
            return customer;
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Customer>();

            filteredList.TotalCount = _customers.Count;
            filteredList.FilterUsed = filter;

            IEnumerable<Customer> filtering = _customers;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "FirstName":
                        filtering = filtering.Where(c => c.FirstName.Contains(filter.SearchText));
                        break;
                    case "LastName":
                        filtering = filtering.Where(c => c.LastName.Contains(filter.SearchText));
                        break;
                }
            }
            
            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Customer).GetProperty(filter.OrderProperty);
                filtering = "ASC".Equals(filter.OrderDirection) ? 
                    filtering.OrderBy(c => prop.GetValue(c, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }

            filteredList.List = filtering.ToList();
            return filteredList;
        }

        public Customer ReadyById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = this.ReadyById(customerUpdate.Id);
            if(customerFromDB != null) {
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.LastName = customerUpdate.LastName;
                customerFromDB.Address = customerUpdate.Address;
                return customerFromDB;
            }
            return null;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.ReadyById(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }
            return null;
        }

        public List<Customer> Filter(string orderDir)
        {
            if ("asc".Equals(orderDir))
            {
                return _customers
                    .OrderBy(c => c.FirstName)
                    .ToList();
            }
            return _customers
                .OrderByDescending(c => c.FirstName)
                .ToList();
        }
    }
}
