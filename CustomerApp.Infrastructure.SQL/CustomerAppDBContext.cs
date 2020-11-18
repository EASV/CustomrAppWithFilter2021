using System;
using System.Linq;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomerApp.Infrastructure.SQL
{
    public class CustomerAppDBContext: DbContext
    {
        public CustomerAppDBContext(
            DbContextOptions<CustomerAppDBContext> opt) : base(opt)
        {
        }

        public void DetachAll()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(city => new {city.ZipCode});
            modelBuilder.Entity<City>()
                .Property(c => c.ZipCode)
                .ValueGeneratedNever();
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => new {a.CityId})
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CityTourist>()
                .HasKey(ct => new {ct.CityId, ct.TouristId});

            modelBuilder.Entity<CityTourist>()
                .HasOne(c => c.City)
                .WithMany(ct => ct.Tourists)
                .HasForeignKey(ct => new {ct.CityId});

            modelBuilder.Entity<CityTourist>()
                .HasOne(c => c.Tourist)
                .WithMany(ct => ct.Cities)
                .HasForeignKey(ct => new {ct.TouristId});


        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hat> Hats { get; set; }
        public DbSet<HatType> HatTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<CityTourist> CityTourists { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}