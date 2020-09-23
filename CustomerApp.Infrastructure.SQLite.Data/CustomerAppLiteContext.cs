using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQLite.Data
{
    public class CustomerAppLiteContext: DbContext
    {
        public CustomerAppLiteContext(DbContextOptions<CustomerAppLiteContext> opt) : base(opt){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(c => new {c.ZipCode});
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}