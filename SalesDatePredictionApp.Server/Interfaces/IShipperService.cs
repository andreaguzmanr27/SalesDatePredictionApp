using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Interfaces
{
    public interface IShipperService
    {
        Task<List<ShipperDTO>> GetShippersAsync();
    }
}
