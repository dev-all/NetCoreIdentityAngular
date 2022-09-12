
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace allshop.repository.Context
{
    public class allshopContext : DbContext
    {
        public allshopContext(DbContextOptions<allshopContext> options) : base(options) { }
        public  DbSet<User> Users { get; set; } = null!;


      
    }
}
