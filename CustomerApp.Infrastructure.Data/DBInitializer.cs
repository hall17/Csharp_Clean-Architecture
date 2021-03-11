using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(CustomerAppContext context)
        {
            context.Database.EnsureDeleted(); // only for development
            context.Database.EnsureCreated();
            var cust1 = context.Customers.Add(new Customer()
            {
                Address = "BongiStreet",
                FirstName = "John",
                LastName = "Olesen"
            }).Entity; 
            var cust2 = context.Customers.Add(new Customer()
            {
                Address = "BongiStreet 22",
                FirstName = "Bill",
                LastName = "Bøllesen"
            }).Entity;
            var order1 = context.Orders.Add(new Order()
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Customer = cust1
            }).Entity;
            context.Orders.Add(new Order()
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Customer = cust1
            });
            context.Orders.Add(new Order()
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Customer = cust2
            });
            context.SaveChanges();
        }
    }
}
