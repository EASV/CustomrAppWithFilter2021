using System.Collections.Generic;

namespace CustomerApp.Core.Models
{
    public class City
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Address> Addresses { get; set; }
        public List<TouristVisit> TouristsVisits { get; set; }
        
    }
}