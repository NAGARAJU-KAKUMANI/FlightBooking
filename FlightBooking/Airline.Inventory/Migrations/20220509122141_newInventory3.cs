using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Inventory.Migrations
{
    public partial class newInventory3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblInventoy",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "BclassAvailCount",
                table: "tblInventoy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "tblInventoy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NBclassAvailableCount",
                table: "tblInventoy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "startTime",
                table: "tblInventoy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblFlight",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblAirLine",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(7893), null });

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(8176), null });

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9597), null });

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9984), null });

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "BclassAvailCount", "CreatedDate", "EndDate", "EndTime", "NBclassAvailableCount", "StartDate", "UpdatedDate", "Updatedby", "startTime" },
                values: new object[] { 50, new DateTime(2022, 5, 9, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 5, 19, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(3681), "12.00 PM", 100, new DateTime(2022, 5, 14, 17, 51, 41, 321, DateTimeKind.Local).AddTicks(2148), null, null, "10.00 AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BclassAvailCount",
                table: "tblInventoy");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "tblInventoy");

            migrationBuilder.DropColumn(
                name: "NBclassAvailableCount",
                table: "tblInventoy");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "tblInventoy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblInventoy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblFlight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblAirLine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tblAirLine",
                keyColumn: "AirlineId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(1023), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(2493), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tblFlight",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 960, DateTimeKind.Local).AddTicks(2758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tblInventoy",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate", "Updatedby" },
                values: new object[] { new DateTime(2022, 5, 9, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(6911), new DateTime(2022, 5, 19, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(3730), new DateTime(2022, 5, 14, 8, 10, 31, 956, DateTimeKind.Local).AddTicks(7997), new DateTime(2022, 5, 9, 8, 10, 31, 958, DateTimeKind.Local).AddTicks(7187), "Admin" });
        }
    }
}
