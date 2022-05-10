using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Booking.Migrations
{
    public partial class newBooking2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 20, 54, 39, 71, DateTimeKind.Local).AddTicks(8910), new DateTime(2022, 5, 19, 20, 54, 39, 70, DateTimeKind.Local).AddTicks(3748), new DateTime(2022, 5, 9, 20, 54, 39, 71, DateTimeKind.Local).AddTicks(9231) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 9, 20, 38, 46, 520, DateTimeKind.Local).AddTicks(8288), new DateTime(2022, 5, 19, 20, 38, 46, 519, DateTimeKind.Local).AddTicks(5297), new DateTime(2022, 5, 9, 20, 38, 46, 520, DateTimeKind.Local).AddTicks(8578) });
        }
    }
}
