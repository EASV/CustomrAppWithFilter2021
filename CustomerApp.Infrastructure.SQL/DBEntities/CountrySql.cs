using System.Collections.Generic;

namespace CustomerApp.Infrastructure.SQL.DBEntities
{
    public class CountrySql
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CitySql> Cities { get; set; }
    }
}