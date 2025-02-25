﻿// <auto-generated />
using System;
using Airline.Inventory.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airline.Inventory.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20220509122141_newInventory3")]
    partial class newInventory3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airline.Inventory.Models.AirLine", b =>
                {
                    b.Property<int>("AirlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updatedby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirlineId");

                    b.ToTable("tblAirLine");

                    b.HasData(
                        new
                        {
                            AirlineId = 1,
                            ActiveStatus = "Y",
                            Address = "Hyderabad",
                            ContactNumber = "9948757854",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(7893),
                            Name = "Cargo"
                        },
                        new
                        {
                            AirlineId = 2,
                            ActiveStatus = "Y",
                            Address = "Banglore",
                            ContactNumber = "9948077376",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(8176),
                            Name = "Indigo"
                        });
                });

            modelBuilder.Entity("Airline.Inventory.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirLineId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updatedby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightID");

                    b.ToTable("tblFlight");

                    b.HasData(
                        new
                        {
                            FlightID = 1,
                            AirLineId = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9597),
                            FlightName = "Enfield",
                            FlightNumber = "V12345"
                        },
                        new
                        {
                            FlightID = 2,
                            AirLineId = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 5, 9, 17, 51, 41, 323, DateTimeKind.Local).AddTicks(9984),
                            FlightName = "FZ-MR",
                            FlightNumber = "VF12345"
                        });
                });

            modelBuilder.Entity("Airline.Inventory.Models.Inventorys", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirLineId")
                        .HasColumnType("int");

                    b.Property<int>("BClassCount")
                        .HasColumnType("int");

                    b.Property<int>("BclassAvailCount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FromPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Meal")
                        .HasColumnType("int");

                    b.Property<int>("NBClassCount")
                        .HasColumnType("int");

                    b.Property<int>("NBclassAvailableCount")
                        .HasColumnType("int");

                    b.Property<int>("Rows")
                        .HasColumnType("int");

                    b.Property<int>("ScheduledDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TicketCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updatedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryId");

                    b.ToTable("tblInventoy");

                    b.HasData(
                        new
                        {
                            InventoryId = 1,
                            AirLineId = 1,
                            BClassCount = 50,
                            BclassAvailCount = 50,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 5, 9, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(6910),
                            EndDate = new DateTime(2022, 5, 19, 17, 51, 41, 322, DateTimeKind.Local).AddTicks(3681),
                            EndTime = "12.00 PM",
                            FlightNumber = "V12345",
                            FromPlace = "BASAR",
                            Instrument = "Insur",
                            Meal = 2,
                            NBClassCount = 100,
                            NBclassAvailableCount = 100,
                            Rows = 5,
                            ScheduledDays = 0,
                            StartDate = new DateTime(2022, 5, 14, 17, 51, 41, 321, DateTimeKind.Local).AddTicks(2148),
                            TicketCost = 2000m,
                            ToPlace = "HYDERABAD",
                            startTime = "10.00 AM"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
