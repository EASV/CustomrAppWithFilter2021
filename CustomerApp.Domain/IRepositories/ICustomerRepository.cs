using System.Collections.Generic;
using CustomerApp.Core.Filter;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.Persistance.Interfaces
{
    public interface ICustomerRepository
    {
        //CustomerRepository Interface
        //Create Data
        //No Id when enter, but Id when exits
        Customer Create(Customer customer);
        //Read Data
        Customer ReadyById(int id);
        FilteredList<Customer> ReadAll(Filter.Filter filter);
        //Update Data
        Customer Update(Customer customerUpdate);
        //Delete Data
        Customer Delete(int id);
        List<Customer> Filter(string orderDir);
    }
}
