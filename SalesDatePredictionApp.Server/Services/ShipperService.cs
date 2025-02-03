using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Services
{
    public class ShipperService : IShipperService
    {
        private readonly StoreSampleContext _context;

        public ShipperService(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<List<ShipperDTO>> GetShippersAsync()
        {
            var shippers = await _context.Shippers
                .Select(s => new ShipperDTO
                {
                    Shipperid = s.Shipperid,
                    Companyname = s.Companyname
                })
            .ToListAsync();

            return shippers;
        }
    }

}
