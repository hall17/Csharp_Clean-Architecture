using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using OrderApp.Core.ApplicationService;
using OrderApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository,ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }
        public Order NewOrder()
        {
            return new Order()
            {

            };
        }
        public Order CreateOrder(Order order)
        {
            if(order.Customer == null ||order.Customer.Id <= 0)
            {
                throw new InvalidDataException("You need a customer to create an order");
            }
            if(_customerRepository.ReadById(order.Customer.Id) == null)
            {
                throw new InvalidDataException("Customer not found");
            }
            if(order.OrderDate == null)
            {
                throw new InvalidDataException("Order needs a Order Date");
            }
            return _orderRepository.Create(order);
        }

      

        public List<Order> GetAllOrders()
        {
            return _orderRepository.ReadAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.ReadById(id);
        }

        public Order UpdateOrder(Order order)
        {
            return _orderRepository.Update(order);
        }
        public Order DeleteOrder(int id)
        {
            return _orderRepository.Delete(id);
        }
    }
}
