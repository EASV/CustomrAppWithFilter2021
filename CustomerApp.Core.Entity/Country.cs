using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}