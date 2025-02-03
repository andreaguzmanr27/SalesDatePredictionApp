using SalesDatePredictionApp.Server.Models;

namespace SalesDatePredictionApp.Server.Interfaces
{
    public interface IOrderPredictionService
    {
        Task<List<OrderPrediction>> UpdateSalesDatePrediction(string? customerName);
    }
}
