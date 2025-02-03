using System;
using System.Collections.Generic;

namespace SalesDatePredictionApp.Server.Models;

public partial class OrderTotalsByYear
{
    public int? Orderyear { get; set; }

    public int? Qty { get; set; }
}
