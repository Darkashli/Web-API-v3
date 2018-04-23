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

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        protected void OnModelCreating(DbModelBuilder modelBuilder)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {

        }
    }
}