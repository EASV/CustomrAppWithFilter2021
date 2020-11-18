using System.Collections.Generic;
using System.Data.Common;

namespace CustomerApp.Core.Entity
{
    public class City
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        //Writing Relational Mapping
        public int CountryId { get; set; }
        
        //Reading Business Object Mapping
        public Country Country { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CityTourist> Tourists { get; set; }
        public List<Tourist> TouristsClean { get; set; }
    }
}