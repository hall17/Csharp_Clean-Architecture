using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer ReadById(int id);
        IEnumerable<Customer> ReadAll();
        Customer Update(Customer customerUpdate);
        Customer Delete(int id);
        Customer ReadByIdIncludeOrders(int id);
    }
}
