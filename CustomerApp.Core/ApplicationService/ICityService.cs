using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICityService
    {
        public List<City> ReadAll();
    }
}