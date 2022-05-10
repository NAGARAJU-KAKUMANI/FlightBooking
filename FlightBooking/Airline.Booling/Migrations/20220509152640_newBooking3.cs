using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Booking.Migrations
{
    public partial class newBooking3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblInventoy",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDays = table.Column<int>(type: "int", nullable: false),
                    Instrument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BClassCount = table.Column<int>(type: "int", nullable: false),
                    BclassAvailCount = table.Column<int>(type: "int", nullable: false),
                    NBClassCount = table.Column<int>(type: "int", nullable: false),
                    NBclassAvailableCount = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rows = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInventoy", x => x.InventoryId);
                });

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 20, 56, 40, 489, DateTimeKind.Local).AddTicks(7328), new DateTime(2022, 5, 19, 20, 56, 40, 488, DateTimeKind.Local).AddTicks(8624), new DateTime(2022, 5, 9, 20, 56, 40, 489, DateTimeKind.Local).AddTicks(7604) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblInventoy");

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 20, 54, 39, 71, DateTimeKind.Local).AddTicks(8910), new DateTime(2022, 5, 19, 20, 54, 39, 70, DateTimeKind.Local).AddTicks(3748), new DateTime(2022, 5, 9, 20, 54, 39, 71, DateTimeKind.Local).AddTicks(9231) });
        }
    }
}
