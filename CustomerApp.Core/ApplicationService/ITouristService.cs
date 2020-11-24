using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ITouristService
    {
        List<Tourist> ReadAll();
    }
}