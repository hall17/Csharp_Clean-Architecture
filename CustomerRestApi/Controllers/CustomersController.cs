using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRestApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAllCustomers();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerService.GetCustomerAndOrdersById(id);
        }
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if(string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("First name is required for creating customer.");
            }
           return  _customerService.CreateCustomer(customer);
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if(id < 1 || id != customer.Id)
            {
                return BadRequest("Parameter Id and customer Id does not match!");
            }
            return Ok(_customerService.UpdateCustomer(customer));
        }
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _customerService.DeleteCustomer(id);
            if (customer == null) return StatusCode(404, "Customer not found");
            return Ok(customer);
        }
    }
}
