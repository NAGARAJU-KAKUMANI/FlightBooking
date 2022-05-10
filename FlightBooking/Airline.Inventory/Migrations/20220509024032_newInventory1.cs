using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Inventory.Migrations
{
    public partial class newInventory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "ScheduledDays", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(6911), new DateTime(2022, 5, 19, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(3730), 0, new DateTime(2022, 5, 14, 8, 10, 31, 956, DateTimeKind.Local).AddTicks(7997), new DateTime(2022, 5, 9, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(7187) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDate", "EndDate", "ScheduledDays", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(9060), new DateTime(2022, 5, 19, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(7042), 20, new DateTime(2022, 5, 14, 8, 4, 29, 766, DateTimeKind.Local).AddTicks(264), new DateTime(2022, 5, 9, 8, 4, 29, 767, DateTimeKind.Local).AddTicks(9422) });
        }
    }
}
