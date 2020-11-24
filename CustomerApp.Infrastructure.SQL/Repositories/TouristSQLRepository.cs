using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class TouristSQLRepository: ITouristRepository
    {
        private CustomerAppDBContext _ctx;

        public TouristSQLRepository(CustomerAppDBContext ctx)
        {
            _ctx = ctx;
        }
        public List<Tourist> GetAll()
        {
            return _ctx.Tourists.ToList();
        }
    }
}