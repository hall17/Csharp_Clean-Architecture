using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp.Core.ApplicationService
{
    public interface IOrderService
    {
        Order NewOrder();

        // C
        Order CreateOrder(Order order);

        // R
        Order GetOrderById(int id);
        List<Order> GetAllOrders();

        // U
        Order UpdateOrder(Order order);


        // D
        Order DeleteOrder(int id);
    }
}
