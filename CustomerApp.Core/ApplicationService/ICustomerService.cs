using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        //New Customer
        Customer NewCustomer(string firstName,
                                string lastName,
                                Address address);

        //Create
        Customer CreateCustomer(Customer cust);
        //Read
        Customer FindCustomerById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref=""></exception>
        FilteredList<Customer> GetAllCustomers(Filter filter);
        //Update
        Customer UpdateCustomer(Customer customerUpdate);
        
        //Delete
        Customer DeleteCustomer(int id);
    }
}
