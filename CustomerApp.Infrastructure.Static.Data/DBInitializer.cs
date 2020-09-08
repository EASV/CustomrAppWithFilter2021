using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data
{
    public class DBInitializer
    {
        private readonly ICustomerRepository _customerRepository;

        public DBInitializer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void InitData()
        {
            _customerRepository.Create(
                new Customer()
                {
                    Address = "Snurfstreet 5",
                    FirstName = "John",
                    LastName = "Bilsson"
                });
            _customerRepository.Create(
                new Customer()
                {
                    Address = "Snurfstreet 3",
                    FirstName = "Bill",
                    LastName = "Bilbo"
                });
            _customerRepository.Create(
                new Customer()
                {
                    Address = "Snurfstreet 2",
                    FirstName = "Bob",
                    LastName = "Snurfheit the 3rd"
                });
            _customerRepository.Create(
                new Customer()
                {
                    Address = "Snurfstreet 234",
                    FirstName = "Little",
                    LastName = "John"
                });
            _customerRepository.Create(
                new Customer()
                {
                    Address = "Snurfstreet 234",
                    FirstName = "Zilbo",
                    LastName = "Zaggins"
                });
            _customerRepository.Create(
                new Customer()
                {
                    Address = "TikkoStreet 22234",
                    FirstName = "Aykoniksotytytjiiimsi",
                    LastName = "OST"
                });
        }
    }
}