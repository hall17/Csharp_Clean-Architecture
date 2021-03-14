using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class CustomerAppContext : DbContext
    {
        public CustomerAppContext(DbContextOptions<CustomerAppContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull); // Order remains just set null value for its customer.

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
