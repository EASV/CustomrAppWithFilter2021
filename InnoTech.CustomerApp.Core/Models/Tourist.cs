using System.Collections.Generic;

namespace InnoTech.CustomerApp.Core.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}