using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.UserRegister.Migrations
{
    public partial class mySecondUserRegistaion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRegistor",
                columns: new[] { "UserID", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "UpdatedDate", "Updatedby", "mobile" },
                values: new object[] { 1, "BASAR", "Admin", new DateTime(2022, 5, 2, 19, 20, 51, 62, DateTimeKind.Local).AddTicks(5249), new DateTime(2022, 5, 2, 19, 20, 51, 61, DateTimeKind.Local).AddTicks(4754), "kakumani@gmail.com", "NAGARAJU", "KAKUMANI", "Pass@word", new DateTime(2022, 5, 2, 19, 20, 51, 62, DateTimeKind.Local).AddTicks(5678), "Admin", "9666491876" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRegistor",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
