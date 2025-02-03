namespace SalesDatePredictionApp.Server.Models
{
    public class OrderPrediction
    {
        public int OrderPredictionId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}
