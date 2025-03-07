using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Way of Old Configration

            //modelBuilder.ApplyConfiguration(new ProductConfig());  
            //modelBuilder.ApplyConfiguration(new CategoryConfig());  
            //modelBuilder.ApplyConfiguration(new BrandConfig());  

            //مميزة Reflections

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Package that Tools Depend On pACKAGE Desgin  



        //Tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }














        //Default Connection
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.UseSqlServer("");
    }
}
