using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerApp.Infrastructure.SQL.Data
{
    public class CustomerAppContext: DbContext
    {   public CustomerAppContext(DbContextOptions<CustomerAppContext> opt) 
            : base(opt) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}