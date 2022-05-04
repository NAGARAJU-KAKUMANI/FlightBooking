using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Inventory.Migrations
{
    public partial class MysecondInventoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAirLine",
                columns: table => new
                {
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAirLine", x => x.AirlineId);
                });

            migrationBuilder.CreateTable(
                name: "tblFlight",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFlight", x => x.FlightID);
                });

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
                    ScheduledDays = table.Column<int>(type: "int", nullable: false),
                    Instrument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BClassCount = table.Column<int>(type: "int", nullable: false),
                    NBClassCount = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rows = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInventoy", x => x.InventoryId);
                });

            migrationBuilder.InsertData(
                table: "tblAirLine",
                columns: new[] { "AirlineId", "ActiveStatus", "Address", "ContactNumber", "CreatedBy", "CreatedDate", "Name", "UpdatedDate", "Updatedby" },
                values: new object[,]
                {
                    { 1, "Y", "Hyderabad", "9948757854", "Admin", new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(6351), "Cargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Y", "Banglore", "9948077376", "Admin", new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(6603), "Indigo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "tblFlight",
                columns: new[] { "FlightID", "AirLineId", "CreatedBy", "CreatedDate", "FlightName", "FlightNumber", "UpdatedDate", "Updatedby" },
                values: new object[,]
                {
                    { 1, 1, "Admin", new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(7619), "Enfield", "V12345", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, "Admin", new DateTime(2022, 5, 2, 18, 49, 45, 582, DateTimeKind.Local).AddTicks(7830), "FZ-MR", "VF12345", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "tblInventoy",
                columns: new[] { "InventoryId", "AirLineId", "BClassCount", "CreatedBy", "CreatedDate", "EndDate", "FlightNumber", "FromPlace", "Instrument", "Meal", "NBClassCount", "Rows", "ScheduledDays", "StartDate", "TicketCost", "ToPlace", "UpdatedDate", "Updatedby" },
                values: new object[] { 1, 1, 50, "Admin", new DateTime(2022, 5, 2, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(5076), new DateTime(2022, 5, 12, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(3673), "V12345", "BASAR", "Insur", 1, 100, 5, 20, new DateTime(2022, 5, 7, 18, 49, 45, 580, DateTimeKind.Local).AddTicks(2669), 2000m, "HYDERABAD", new DateTime(2022, 5, 2, 18, 49, 45, 581, DateTimeKind.Local).AddTicks(5460), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAirLine");

            migrationBuilder.DropTable(
                name: "tblFlight");

            migrationBuilder.DropTable(
                name: "tblInventoy");
        }
    }
}
