using MarketPlaceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
               .HasOne(c => c.ParentCategory)
               .WithMany(c => c.ChildCategories)
               .HasForeignKey(c => c.ParentCategoryId);


            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductImages>()
              .HasOne(pi => pi.Product)
              .WithMany(p => p.ProductImages)
              .HasForeignKey(pi => pi.ProductId);
        }
    }
}
