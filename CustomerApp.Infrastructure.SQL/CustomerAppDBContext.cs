using System;
using System.Linq;
using CustomerApp.Infrastructure.SQL.DBEntities;
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
            //Fluent API
            modelBuilder.Entity<CitySql>()
                .Property(c => c.ZipCode)
                .ValueGeneratedNever();
            modelBuilder.Entity<CitySql>()
                .HasKey(city => new {city.ZipCode});
            modelBuilder.Entity<AddressSql>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => new {a.CityId})
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CityTouristSql>()
                .HasKey(ct => new {ct.CityId, ct.TouristId});

            modelBuilder.Entity<CityTouristSql>()
                .HasOne(c => c.City)
                .WithMany(ct => ct.Tourists)
                .HasForeignKey(ct => new {ct.CityId});

            modelBuilder.Entity<CityTouristSql>()
                .HasOne(c => c.Tourist)
                .WithMany(ct => ct.Cities)
                .HasForeignKey(ct => new {ct.TouristId});


        }
        
        public DbSet<CustomerSql> Customers { get; set; }
        public DbSet<AddressSql> Addresses { get; set; }
        public DbSet<CitySql> Cities { get; set; }
        public DbSet<TouristSql> Tourists { get; set; }
        public DbSet<CityTouristSql> CityTourists { get; set; }
        public DbSet<CountrySql> Countries { get; set; }
    }
}