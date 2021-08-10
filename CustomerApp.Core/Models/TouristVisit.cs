using System;

namespace CustomerApp.Core.Models
{
    public class TouristVisit
    {
        public DateTime VisitTime { get; set; }
        public Tourist Tourist { get; set; }
    }
}