using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNr { get; set; }
        public string Additional { get; set; }
        // WRITE/UPDATE/DELETE Relational ID in the table 
        public int CityId { get; set; }
        // Read Domain object
        public City City { get; set; }
        public List<Customer> Customers { get; set; }
    }
}