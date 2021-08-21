using System.Collections.Generic;
using InnoTech.CustomerApp.Core.Filter;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        //CustomerRepository Interface
        //Create Data
        //No Id when enter, but Id when exits
        Customer Create(Customer customer);
        //Read Data
        Customer ReadyById(int id);
        FilteredList<Customer> ReadAll(InnoTech.CustomerApp.Core.Filter.Filter filter);
        //Update Data
        Customer Update(Customer customerUpdate);
        //Delete Data
        Customer Delete(int id);
        List<Customer> Filter(string orderDir);
    }
}
