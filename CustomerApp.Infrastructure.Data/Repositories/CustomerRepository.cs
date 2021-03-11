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

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _context.Customers;
        }

        public Customer ReadById(int id)
        {
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
    }
}
