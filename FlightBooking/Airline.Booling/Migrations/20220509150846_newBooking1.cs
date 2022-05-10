using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Booking.Migrations
{
    public partial class newBooking1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BoardingTime",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Seattype",
                table: "tblBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "BoardingTime", "CreatedDate", "DateOfJourney", "Seattype", "UpdatedDate" },
                values: new object[] { "10.00 AM", new DateTime(2022, 5, 9, 20, 38, 46, 520, DateTimeKind.Local).AddTicks(8288), new DateTime(2022, 5, 19, 20, 38, 46, 519, DateTimeKind.Local).AddTicks(5297), 0, new DateTime(2022, 5, 9, 20, 38, 46, 520, DateTimeKind.Local).AddTicks(8578) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seattype",
                table: "tblBookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BoardingTime",
                table: "tblBookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "BoardingTime", "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 19, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(741), new DateTime(2022, 5, 9, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(2080), new DateTime(2022, 5, 19, 7, 29, 5, 198, DateTimeKind.Local).AddTicks(6971), new DateTime(2022, 5, 9, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(2397) });
        }
    }
}
