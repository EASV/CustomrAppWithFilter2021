using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNr { get; set; }
        public string Additional { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Customer> Customers { get; set; }
    }
}