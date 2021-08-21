using System;

namespace InnoTech.CustomerApp.Core.Models
{
    public class TouristVisit
    {
        public DateTime VisitTime { get; set; }
        public Tourist Tourist { get; set; }
    }
}