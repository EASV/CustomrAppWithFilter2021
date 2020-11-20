using System;

namespace CustomerApp.Infrastructure.SQL.DBEntities
{
    public class CityTouristSql
    {
        //Relations
        public int CityId { get; set; }
        //BusinessObject Mapping / Read
        public CitySql City { get; set; }
        
        public int TouristId { get; set; }
        public TouristSql Tourist { get; set; }
        public DateTime VisitDate { get; set; }
    }
}