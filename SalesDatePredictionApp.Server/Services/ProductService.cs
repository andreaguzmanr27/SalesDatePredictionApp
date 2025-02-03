using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreSampleContext _context;

        public ProductService(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Productid = p.Productid,
                    Productname = p.Productname
                })
            .ToListAsync();

            return products;
        }
    }

}
