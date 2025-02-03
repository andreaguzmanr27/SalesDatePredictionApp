using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();
    }
}
