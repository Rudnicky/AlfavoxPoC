using AlfavoxPoC.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alfavox.Persistence
{
    public class AlfavoxDbContext : DbContext
    {
        public AlfavoxDbContext(DbContextOptions<AlfavoxDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Company> Compenies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Employees);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Locations);

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Products);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company);

            modelBuilder.Entity<Location>()
                .HasOne(x => x.Company);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Company);
        }
    }
}
