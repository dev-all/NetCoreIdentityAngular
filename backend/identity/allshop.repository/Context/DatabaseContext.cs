
using allshop.domain.Entities;
using allshop.domain.Entities.Auth;
using allshop.repository.Contracts;
using DataAccess.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace allshop.repository.Context
{
    public class DatabaseContext : IdentityDbContext<AuthUser, AuthRole, string>, IAppDBContext
    {
        //public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Role> Roles { get; set; }
        
        public DbSet<Customer> Customers { get; set; }       
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<AuthRole> AuthRoles { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableSensitiveDataLogging();

   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CustomerConfig.SetEntityBuilder(modelBuilder.Entity<Customer>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
