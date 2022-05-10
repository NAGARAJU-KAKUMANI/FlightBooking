using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Booking.Migrations
{
    public partial class Bookingsnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblBookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "BoardingTime", "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 19, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(741), new DateTime(2022, 5, 9, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(2080), new DateTime(2022, 5, 19, 7, 29, 5, 198, DateTimeKind.Local).AddTicks(6971), new DateTime(2022, 5, 9, 7, 29, 5, 200, DateTimeKind.Local).AddTicks(2397) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tblBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755",
                columns: new[] { "BoardingTime", "CreatedDate", "DateOfJourney", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 12, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(1173), new DateTime(2022, 5, 2, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(2242), new DateTime(2022, 5, 12, 19, 11, 43, 981, DateTimeKind.Local).AddTicks(863), new DateTime(2022, 5, 2, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(2519) });
        }
    }
}
