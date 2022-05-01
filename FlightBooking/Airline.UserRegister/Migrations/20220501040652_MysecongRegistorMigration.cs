using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.UserRegister.Migrations
{
    public partial class MysecongRegistorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserRegistor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserRegistor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserRegistor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "UserRegistor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserRegistor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserRegistor");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserRegistor");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "UserRegistor");
        }
    }
}
