using CafeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Persistence.Context
{
    public class CafeManagementDBContext : DbContext
    {
        public CafeManagementDBContext(DbContextOptions<CafeManagementDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<CafeEmployee> CafeEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for CafeEmployee
            modelBuilder.Entity<CafeEmployee>()
                .HasKey(ce => new { ce.CafeId, ce.EmployeeID });

            // Configure properties for Employee
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeId)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmailAddress)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Cafe>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Cafe>()
                .HasIndex(e => e.Location);

            modelBuilder.Entity<Employee>().Navigation(e => e.Cafe).AutoInclude();
            modelBuilder.Entity<Employee>().Navigation(e => e.CafeEmployee).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }
    }
}
