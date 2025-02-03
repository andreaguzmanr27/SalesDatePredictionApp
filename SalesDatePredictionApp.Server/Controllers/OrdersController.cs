using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(StoreSampleContext context, IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{customerName}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerName(string customerName)
        {
            var orders = await _orderService.GetOrdersByCustomerNameAsync(customerName);
            return Ok(orders);
        }

        [HttpPost("AddNewOrder")]
        public async Task<IActionResult> AddNewOrder([FromBody] AddNewOrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                return StatusCode(500, new { message = "Order request is null." });
            }

            var result = await _orderService.AddNewOrderAsync(orderRequest);
            if (!result)
            {
                return StatusCode(500, new { message = "An error occurred while processing the order." });
            }

            return Ok(new { message = "Order added successfully." });
        }

    }
}
