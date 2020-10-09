using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IHatRepository _hatRepository;

        public DBInitializer(
                 IHatRepository hatRepository,
                 ICityRepository cityRepository, 
                 ICustomerRepository customerRepository,
                 IAddressRepository addressRepository)
        {
            _hatRepository = hatRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
        }

        public void InitData()
        {
            /*var brand = new Brand()
            {
                Name = "The Brand"
            };
            var color = new Color()
            {
                Name = "Blue"
            };
            var type = new HatType()
            {
                Name = "ClapeHat"
            };
            var type2 = new HatType()
            {
                Name = "KlouwnHat"
            };
            var hat = new Hat()
            {
                Brand = brand,
                Color = color,
                Name = "Hatten",
                HatType = type
            };
            _hatRepository.Create(hat);
            
            var hat2 = new Hat()
            {
                BrandId = 1,
                ColorId = 1,
                Name = "Hatten Der Kunne finde hjem selv",
                HatTypeId = 1
            };
            _hatRepository.Create(hat2);
            var hat2Updated = new Hat
            {
                Id = hat2.Id,
                HatTypeId = 1,
                Name = "Ostebollehatten20"
            };

            _hatRepository.Update(hat2Updated);
            
            /*
            var hat2 = new Hat()
            {
                Brand = brand,
                Color = color,
                Name = "Hatten Der Kunne finde hjem selv",
                HatType = type2
            };
            hat2 = _hatRepository.Create(hat2);

            
            var hat3 = new Hat
            {
                Id = hat2.Id,
                Brand = null,
                Color = null,
                HatType = type,
                Name = hat2.Name
            };

            _hatRepository.Update(hat3);
            
            var hat4 = new Hat
            {
                Brand = null,
                Color = color,
                HatType = type,
                Name = "ostehatten"
            };

            _hatRepository.Create(hat4);
            */
            /*City city = _cityRepository.Create(new City()
            {
                ZipCode = 6000,
                Name = "Kolding"
            });
            _cityRepository.Create(city);*/
            var listCities = new List<City>();
            for (int i = 0; i < 5; i++)
            {
                listCities.Add(new City()
                {
                    ZipCode = 6001 + i,
                    Name = "osteBy" + i
                });
            }
            _cityRepository.CreateAll(listCities);
            /*var address = new Address
            {
                Id = 1,
                StreetName = "Øffgade",
                StreetNr = 7,
                Additional = "TTL",
                Customers = new List<Customer>(),
                //CityId = city.ZipCode
            };
            _addressRepository.Create(address);
            /*
            Customer cust;
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "John",
                    LastName = "Bilsson"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Bill",
                    LastName = "Bilbo"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Bob",
                    LastName = "Snurfheit the 3rd"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Little",
                    LastName = "John"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
                cust = new Customer()
                {
                    Address = address,
                    FirstName = "Zilbo",
                    LastName = "Zaggins"
                });
            address.Customers.Add(cust);
            _customerRepository.Create(
               cust = new Customer()
                {
                    Address = address,
                    FirstName = "Aykoniksotytytjiiimsi",
                    LastName = "OST"
                });
            address.Customers.Add(cust);
*/
        }
    }
}