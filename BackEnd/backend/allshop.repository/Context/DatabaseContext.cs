
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace allshop.repository.Context
{
    public class DatabaseContext : DbContext
    {
       // public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableSensitiveDataLogging();

        public  DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        ///  Create default roles with migration
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    CreatedAt = DateTime.Now
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
