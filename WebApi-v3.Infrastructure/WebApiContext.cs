using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_v3.Domain;


namespace WebApi_v3.Infrastructure
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("WebApiDatabase")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
            //    .HasMany(o => o.Products);

            //var products = modelBuilder.Entity<Product>();
            //products.HasMany(o => o.Customers);
            //products.HasRequired(o => o.Employee).
        }
    }
}