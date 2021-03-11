using CustomerApp.Core.Entity;
using OrderApp.Core.DomainService;
using System;
using System.Collections.Generic;
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
        public Order Create(Order Order)
        {
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return Order;
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll()
        {
            return _context.Orders;
        }

        public Order ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order OrderUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
