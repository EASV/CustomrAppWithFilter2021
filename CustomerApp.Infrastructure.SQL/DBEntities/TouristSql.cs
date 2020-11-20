using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.SQL.DBEntities
{
    public class TouristSql
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityTouristSql> Cities { get; set; }
    }
}