using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Inventory.Migrations
{
    public partial class newInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 4, 29, 769, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 4, 29, 769, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 4, 29, 769, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 4, 29, 769, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "Meal", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(9060), new DateTime(2022, 5, 19, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(7042), 2, new DateTime(2022, 5, 14, 8, 4, 29, 766, DateTimeKind.Local).AddTicks(264), new DateTime(2022, 5, 9, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(9422) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "Meal", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(5076), new DateTime(2022, 5, 12, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(3673), 1, new DateTime(2022, 5, 7, 18, 49, 45, 580, DateTimeKind.Local).AddTicks(2669), new DateTime(2022, 5, 2, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(5460) });
        }
    }
}
