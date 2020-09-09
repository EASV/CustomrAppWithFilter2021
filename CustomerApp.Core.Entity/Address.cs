using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public List<Customer> Customers { get; set; }

    }
}