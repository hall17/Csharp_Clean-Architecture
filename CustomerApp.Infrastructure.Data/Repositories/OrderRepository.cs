using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using OrderApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CustomerAppContext _context;

        public OrderRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public Order Create(Order order)
        {
            _context.Attach(order).State = EntityState.Added;
            _context.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll(Filter filter)
        {
            if(filter == null) 
            {
                return _context.Orders;
            }
            return _context.Orders
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                    .Take(filter.ItemsPerPage);
        }

        public Order ReadByIdIncludeCustomer(int id)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.Id == id);

        }

        public Order Update(Order OrderUpdate)
        {

            _context.Attach(OrderUpdate).State = EntityState.Modified;
            _context.Entry(OrderUpdate).Reference(o => o.Customer).IsModified = true;
            _context.SaveChanges();
            return OrderUpdate;
        }

        public int Count()
        {
            return _context.Orders.Count();
        }
    }
}
