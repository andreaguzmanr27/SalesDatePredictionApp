using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreSampleContext _context;

        public OrderService(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetOrdersByCustomerNameAsync(string customerName)
        {
            var orders = await _context.Orders
              .Where(o => o.Cust != null && o.Cust.Companyname == customerName)
              .Select(o => new OrderDto
              {
                  Orderid = o.Orderid,
                  Requireddate = o.Requireddate,
                  Shippeddate = o.Shippeddate,
                  Shipname = o.Shipname,
                  Shipaddress = o.Shipaddress,
                  Shipcity = o.Shipcity
              })
              .ToListAsync();

            return orders;
        }

        public async Task<bool> AddNewOrderAsync(AddNewOrderRequest orderRequest)
        {
            try
            {
                var customerId = await _context.Customers
                    .Where(c => c.Companyname == orderRequest.CustomerName)
                    .Select(c => c.Custid)
                    .FirstOrDefaultAsync();

                if (customerId == 0)
                {
                    return false;
                }

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC AddNewOrder @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14",
                    customerId,
                    orderRequest.EmpId,
                    orderRequest.ShipperId,
                    orderRequest.ShipName,
                    orderRequest.ShipAddress,
                    orderRequest.ShipCity,
                    orderRequest.OrderDate,
                    orderRequest.RequiredDate,
                    orderRequest.ShippedDate,
                    orderRequest.Freight,
                    orderRequest.ShipCountry,
                    orderRequest.ProductId,
                    orderRequest.UnitPrice,
                    orderRequest.Qty,
                    orderRequest.Discount
                );

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
