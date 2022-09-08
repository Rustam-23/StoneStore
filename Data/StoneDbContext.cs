using Microsoft.EntityFrameworkCore;
using StoneStore.Models;

namespace StoneStore.Data
{
    public class StoneDbContext : DbContext
    {
        public StoneDbContext(DbContextOptions<StoneDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}