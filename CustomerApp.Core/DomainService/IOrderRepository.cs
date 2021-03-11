using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp.Core.DomainService
{
    public interface IOrderRepository
    {
        Order Create(Order Order);
        Order ReadById(int id);
        IEnumerable<Order> ReadAll();
        Order Update(Order OrderUpdate);
        Order Delete(int id);
    }
}
