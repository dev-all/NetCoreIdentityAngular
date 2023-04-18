
using allshop.domain.Entities;
using allshop.domain.Entities.Auth;
using allshop.repository.Contracts;
using DataAccess.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace allshop.repository.Context
{
    public class DatabaseContext : IdentityDbContext<AuthUser, AuthRole, string>, IAppDBContext
    {
     
        public DbSet<AuthUser> AuthUsers => Set<AuthUser>();
        public DbSet<AuthRole> AuthRoles => Set<AuthRole>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Direccion> Direcciones => Set<Direccion>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<ProductoMasOpciones> ProductoMasOpciones => Set<ProductoMasOpciones>();
        public DbSet<ProductoProveedor> ProductoProveedor => Set<ProductoProveedor>();
        public DbSet<ProductoSize> ProductoSize => Set<ProductoSize>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Imputacion> Imputaciones => Set<Imputacion>();
        public DbSet<ProductoEstado> ProductoEstado => Set<ProductoEstado>();
        public DbSet<Size> Size => Set<Size>();
        public DbSet<Pais> Pais => Set<Pais>();
        public DbSet<Provincia> Provincias => Set<Provincia>();
        public DbSet<Localidad> Localidad => Set<Localidad>();

        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableSensitiveDataLogging();

   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            base.OnModelCreating(modelBuilder);
            /// aplicamos todas las EntityConfig
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
