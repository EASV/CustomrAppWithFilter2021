using System.Collections.Generic;

namespace CustomerApp.Core.Entity
{
    public class City
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }
}