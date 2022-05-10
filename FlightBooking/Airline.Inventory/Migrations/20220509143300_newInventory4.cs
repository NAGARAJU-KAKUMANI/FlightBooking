using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Inventory.Migrations
{
    public partial class newInventory4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 20, 3, 0, 430, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 20, 3, 0, 430, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 20, 3, 0, 430, DateTimeKind.Local).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 20, 3, 0, 430, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 9, 20, 3, 0, 428, DateTimeKind.Local).AddTicks(8583), new DateTime(2022, 5, 19, 20, 3, 0, 428, DateTimeKind.Local).AddTicks(5358), new DateTime(2022, 5, 14, 20, 3, 0, 427, DateTimeKind.Local).AddTicks(2347) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 5, 19, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(3681), new DateTime(2022, 5, 14, 17, 51, 41, 321, DateTimeKind.Local).AddTicks(2148) });
        }
    }
}
