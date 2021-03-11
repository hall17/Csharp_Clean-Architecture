using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        Customer NewCustomer(string firstName,
                             string lastName,
                              string address);

        // C
        Customer CreateCustomer(Customer cust);

        // R
        Customer GetCustomerById(int id);
        Customer GetCustomerAndOrdersById(int id);
        List<Customer> GetAllCustomers();
        List<Customer> GetAllByFirstName(string name);


        // U
        Customer UpdateCustomer(Customer customer);


        // D
        Customer DeleteCustomer(int id);
    }
}
