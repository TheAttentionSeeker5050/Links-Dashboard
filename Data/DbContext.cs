using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebAppProject3.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAppProject3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your entity DbSet properties here
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LinkModel> Links { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        
    }

    
}
