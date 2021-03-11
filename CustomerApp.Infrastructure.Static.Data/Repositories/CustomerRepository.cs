using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //static int id = 1;
        //private List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
            if (FakeDB.Customers.Count >= 1) return;
            var cust1 = new Customer()
            {
                Id = FakeDB.id++,
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            FakeDB.Customers.Add(cust1);
            var cust2 = new Customer()
            {
                Id = FakeDB.id++,
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            FakeDB.Customers.Add(cust2);
        }

        public Customer Create(Customer customer)
        {
            customer.Id = ++FakeDB.id;
            FakeDB.Customers.Add(customer);
            return customer;
        }



        public IEnumerable<Customer> ReadAll()
        {
            return FakeDB.Customers;
        }

        public Customer ReadById(int id)
        {
            return FakeDB.Customers
                .Select(c => new Customer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address
                })
                .FirstOrDefault(customer => customer.Id == id);
        }


        // Remove later when we use UOW
        public Customer Update(Customer customerUpdate)
        {
            var customer = ReadById(customerUpdate.Id);
            if (customer == null) return null;
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.Address = customerUpdate.Address;
            return customer;
        }

        public Customer Delete(int id)
        {
            var customer = ReadById(id);
            if (customer == null) return null;
            FakeDB.Customers.Remove(customer);
            return customer;
        }
    }
}
