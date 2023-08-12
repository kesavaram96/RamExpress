using Microsoft.EntityFrameworkCore;
using RamExpress.Models;

namespace RamExpress.Data
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoriest{ get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ReviewRatings> ReviewRatings { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
     



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
        //        new Category { Id = 2, Name = "Sci fi", DisplayOrder = 2 },
        //        new Category { Id = 3, Name = "Horror", DisplayOrder = 3 }
        //        );
        //}
    }
}


