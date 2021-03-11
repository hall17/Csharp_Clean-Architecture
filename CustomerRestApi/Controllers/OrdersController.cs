using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAllOrders();
        }
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderById(id);
        }
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order Order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(Order));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order Order)
        {
            if (id < 1 || id != Order.Id)
            {
                return BadRequest("Parameter Id and Order Id does not match!");
            }
            return Ok(_orderService.UpdateOrder(Order));
        }
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            var Order = _orderService.DeleteOrder(id);
            if (Order == null) return StatusCode(404, "Order not found");
            return Ok(Order);
        }
    }
}
