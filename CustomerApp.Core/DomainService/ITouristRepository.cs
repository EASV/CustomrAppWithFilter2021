using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ITouristRepository
    {
        public List<Tourist> GetAll();

    }
}