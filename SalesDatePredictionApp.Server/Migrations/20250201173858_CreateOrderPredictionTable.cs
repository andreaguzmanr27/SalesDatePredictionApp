using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesDatePredictionApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderPredictionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderPredictions",
                columns: table => new
                {
                    OrderPredictionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPredictedOrder = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPredictions", x => x.OrderPredictionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPredictions");
        }
    }
}
