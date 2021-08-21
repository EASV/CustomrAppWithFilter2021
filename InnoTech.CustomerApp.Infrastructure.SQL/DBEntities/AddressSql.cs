using System.Collections.Generic;

namespace InnoTech.CustomerApp.Infrastructure.SQL.DBEntities
{
    public class AddressSql
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNr { get; set; }
        public string Additional { get; set; }
        // WRITE/UPDATE/DELETE Relational ID in the table 
        public int CityId { get; set; }
        // Read Domain object
        public CitySql City { get; set; }
        public List<CustomerSql> Customers { get; set; }
    }
}