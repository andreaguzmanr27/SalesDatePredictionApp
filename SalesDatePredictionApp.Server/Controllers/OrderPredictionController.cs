using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderPredictionController : ControllerBase
    {
        private readonly IOrderPredictionService _orderPredictionService;

        public OrderPredictionController(IOrderPredictionService orderPredictionService)
        {
            _orderPredictionService = orderPredictionService;
        }

        [HttpPost("UpdateSalesDatePrediction")]
        public async Task<IActionResult> UpdateSalesDatePrediction([FromBody] UpdateSalesDatePredictionRequest body)
        {
            string? customerName = body.CustomerName;
            var predictions = await _orderPredictionService.UpdateSalesDatePrediction(customerName);

            return Ok(predictions);
        }
    }
}
