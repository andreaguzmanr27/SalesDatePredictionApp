using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models;

namespace SalesDatePredictionApp.Server.Services
{
    public class OrderPredictionService : IOrderPredictionService
    {
        private readonly StoreSampleContext _context;

        public OrderPredictionService(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<List<OrderPrediction>> UpdateSalesDatePrediction(string? customerName)
        {
            var customers = await _context.Customers.ToListAsync();
            var predictions = new List<OrderPrediction>();

            foreach (var customer in customers)
            {
                var orders = await _context.Orders
                    .Where(o => o.Custid == customer.Custid)
                    .OrderBy(o => o.Orderdate)
                    .ToListAsync();

                if (orders.Count < 2)
                {
                    continue;
                }

                var dateDifferences = new List<int>();

                for (int i = 1; i < orders.Count; i++)
                {
                    var previousOrder = orders[i - 1];
                    var currentOrder = orders[i];

                    var daysBetween = (currentOrder.Orderdate - previousOrder.Orderdate).Days;
                    dateDifferences.Add(daysBetween);
                }

                var averageDaysBetweenOrders = dateDifferences.Average();

                var lastOrderDate = orders.Last().Orderdate;
                var nextPredictedOrderDate = lastOrderDate.AddDays(averageDaysBetweenOrders);

                var existingPrediction = await _context.OrderPredictions
                    .FirstOrDefaultAsync(op => op.CustomerName == customer.Companyname);

                if (existingPrediction != null)
                {
                    existingPrediction.LastOrderDate = lastOrderDate;
                    existingPrediction.NextPredictedOrder = nextPredictedOrderDate;
                }
                else
                {
                    var orderPrediction = new OrderPrediction
                    {
                        CustomerName = customer.Companyname,
                        LastOrderDate = lastOrderDate,
                        NextPredictedOrder = nextPredictedOrderDate
                    };

                    predictions.Add(orderPrediction);
                }
            }

            if (predictions.Any())
            {
                await _context.OrderPredictions.AddRangeAsync(predictions);
            }

            await _context.SaveChangesAsync();

            var query = _context.OrderPredictions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query = query.Where(op => op.CustomerName.Contains(customerName));
            }

            var orderPredictions = await query.ToListAsync();

            return orderPredictions;
        }
    }

}
