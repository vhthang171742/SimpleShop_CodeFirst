using SimpleShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.DbContexts
{
    public class SimpleShopContext : DbContext
    {
        public SimpleShopContext()
        {

        }

        public SimpleShopContext(DbContextOptions<SimpleShopContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MasterCard> MasterCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SimpleShop"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>().HasKey(po => new { po.OrderCode, po.ProductId });
            modelBuilder.Entity<MasterCard>().HasOne(mc=>mc.Customer).WithOne(c=>c.MasterCard);
            modelBuilder.Entity<ATMCard>().HasOne(atm=>atm.Customer).WithOne(c=>c.ATMCard);
            modelBuilder.Entity<Product>().HasOne(p=>p.Category).WithMany(c=>c.Products);
            modelBuilder.Entity<Order>().HasOne(o=>o.Customer).WithMany(c=>c.Orders);
        }
    }
}
