using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using OrderApp.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerService(ICustomerRepository customerRepository,IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }
        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var cust = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };
            return cust;
        }
        public Customer CreateCustomer(Customer cust)
        {
            
            return _customerRepository.Create(cust);
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.ReadById(id);
        }
        public Customer GetCustomerAndOrdersById(int id)
        {
            var customer = _customerRepository.ReadByIdIncludeOrders(id);          
            return customer;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.ReadAll().ToList();
        }
        public List<Customer> GetAllByFirstName(string name)
        {
            var list = _customerRepository.ReadAll();
            var queryContinued = list.Where(cust => cust.FirstName.Equals(name));
            queryContinued.OrderBy(customer => customer.FirstName);
            return queryContinued.ToList();
        }
        public Customer UpdateCustomer(Customer cust)
        {
            var customer = GetCustomerById(cust.Id);
            customer.FirstName = cust.FirstName;
            customer.LastName = cust.LastName;
            customer.Address = cust.Address;
            return customer;
        }
        public Customer DeleteCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }
    }
}
