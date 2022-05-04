using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Booking.Migrations
{
    public partial class MysecondBookingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "tblBookings");

            migrationBuilder.AlterColumn<string>(
                name: "passportNumber",
                table: "tblBookings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "tblBookings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToPlace",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Statusstr",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeatNumber",
                table: "tblBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromPlace",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookingID",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "tblBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailID",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "tblBookings",
                columns: new[] { "TicketID", "Age", "BoardingTime", "BookingID", "CreatedBy", "CreatedDate", "DateOfJourney", "EmailID", "FlightNumber", "FromPlace", "SeatNumber", "Status", "Statusstr", "ToPlace", "UpdatedDate", "Updatedby", "UserName", "passportNumber" },
                values: new object[] { "TICK585755", 25, new DateTime(2022, 5, 12, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(1173), "BCK125458", "NAGARAJU", new DateTime(2022, 5, 2, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(2242), new DateTime(2022, 5, 12, 19, 11, 43, 981, DateTimeKind.Local).AddTicks(863), "kakumani15@gmail.com", "V12345", "Hyderabd", 2, 1, "TicketBooked", "BASR", new DateTime(2022, 5, 2, 19, 11, 43, 982, DateTimeKind.Local).AddTicks(2519), "NAGARAJU", "NAGARAJU", "V655585" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblBookings",
                keyColumn: "TicketID",
                keyValue: "TICK585755");

            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "tblBookings");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "tblBookings");

            migrationBuilder.AlterColumn<string>(
                name: "passportNumber",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ToPlace",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Statusstr",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeatNumber",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FromPlace",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookingID",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "tblBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "tblBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
