using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models;

namespace SalesDatePredictionApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
    }
}
