using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerAppContext _context;

        public CustomerRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public Customer Create(Customer customer)
        {
            var cust = _context.Customers.Add(customer).Entity;
            _context.SaveChanges();
            return cust;
        }     

        public IEnumerable<Customer> ReadAll()
        {
            return _context.Customers;
        }

        public Customer ReadById(int id)
        {
            var changeTracker = _context.ChangeTracker.Entries<Customer>();
            return _context.Customers
                .FirstOrDefault(c => c.Id == id);
        }

        public Customer ReadByIdIncludeOrders(int id)
        {
            return _context.Customers
                            .Include(cus => cus.Orders)
                            .FirstOrDefault(c => c.Id == id);
        }

        public Customer Update(Customer customerUpdate)
        {
            throw new NotImplementedException();
        }
        public Customer Delete(int id)
        {
            /*var ordersToRemove = _context.Orders.Where(o => o.Customer.Id == id);
            _context.RemoveRange(ordersToRemove); */
            var customerRemoved = _context.Remove(new Customer() { Id = id }).Entity;
            _context.SaveChanges();
            return customerRemoved;
        }
    }
}
