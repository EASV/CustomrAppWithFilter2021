using System;

namespace CustomerApp.Core.Entity
{
    public class TouristVisit
    {
        public DateTime VisitTime { get; set; }
        public Tourist Tourist { get; set; }
    }
}