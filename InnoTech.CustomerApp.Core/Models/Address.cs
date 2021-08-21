using System.Collections.Generic;

namespace InnoTech.CustomerApp.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNr { get; set; }
        public string Additional { get; set; }
        public City City { get; set; }
        public List<Customer> Customers { get; set; }
    }
}