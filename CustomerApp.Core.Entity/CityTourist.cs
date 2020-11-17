using System;

namespace CustomerApp.Core.Entity
{
    public class CityTourist
    {
        //Relations
        public int CityId { get; set; }
        //BusinessObject Mapping / Read
        public City City { get; set; }
        
        public int TouristId { get; set; }
        public Tourist Tourist { get; set; }
        public DateTime VisitDate { get; set; }
    }
}