using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.MSSQL.Data
{
    public class CustomerAppContext: DbContext
    {
        public CustomerAppContext(DbContextOptions<CustomerAppContext> opt) 
            : base(opt) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}