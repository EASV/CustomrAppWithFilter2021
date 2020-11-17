using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class Tourist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityTourist> Cities { get; set; }
    }
}