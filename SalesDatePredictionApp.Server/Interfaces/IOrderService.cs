using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrdersByCustomerNameAsync(string customerName);
        Task<bool> AddNewOrderAsync(AddNewOrderRequest orderRequest);
    }
}
