using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoneStore.Models;

namespace StoneStore.Data
{
    public class StoneDbContext : IdentityDbContext
    {
        public StoneDbContext(DbContextOptions<StoneDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}