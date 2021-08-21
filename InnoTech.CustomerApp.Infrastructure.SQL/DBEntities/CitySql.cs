using System.Collections.Generic;

namespace InnoTech.CustomerApp.Infrastructure.SQL.DBEntities
{
    public class CitySql
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        //Writing Relational Mapping
        public int CountryId { get; set; }
        //Reading Business Object Mapping
        public CountrySql Country { get; set; }
        public List<AddressSql> Addresses { get; set; }
        public List<CityTouristSql> Tourists { get; set; }

    }
}