using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class CustomerAppContext : DbContext
    {
        public CustomerAppContext(DbContextOptions<CustomerAppContext> options): base(options)
        {
  
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
