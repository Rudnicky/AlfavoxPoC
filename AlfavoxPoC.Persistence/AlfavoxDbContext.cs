using AlfavoxPoC.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlfavoxPoC.Persistence
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
        public DbSet<CompanyEmployee> CompanyEmployee { get; set; }
        public DbSet<CompanyLocation> CompanyLocation { get; set; }
        public DbSet<CompanyProduct> CompanyProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEmployee>()
                .HasKey(k => new { k.CompanyId, k.EmployeeId });

            modelBuilder.Entity<CompanyLocation>()
                .HasKey(k => new { k.CompanyId, k.LocationId });

            modelBuilder.Entity<CompanyProduct>()
                .HasKey(k => new { k.CompanyId, k.ProductId });

            // auto-increment PostgreSql value generation
            modelBuilder.ForNpgsqlUseIdentityColumns();
        }
    }
}
