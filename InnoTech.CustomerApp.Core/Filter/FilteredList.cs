using System.Collections.Generic;

namespace InnoTech.CustomerApp.Core.Filter
{
    public class FilteredList<T>
    {
        public Filter FilterUsed { get; set; }
        public int TotalCount { get; set; }
        public List<T> List { get; set; }
        
    }
}