using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models;

namespace SalesDatePredictionApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet(Name = "GetShippers")]
        public async Task<ActionResult<IEnumerable<Shipper>>> Get()
        {
            var shippers = await _shipperService.GetShippersAsync();
            return Ok(shippers);
        }
    }
}
