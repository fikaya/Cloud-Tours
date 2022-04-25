﻿// <auto-generated />
using CloudTours.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudTours.Persistence.Migrations
{
    [DbContext(typeof(CloudToursDbContext))]
    [Migration("20220416133135_Buses")]
    partial class Buses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudTours.Domain.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusModelId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceTraveled")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationPlate")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("SeatMapping")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.HasIndex("BusModelId");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            BusId = 1,
                            BusModelId = 2,
                            DistanceTraveled = 50000,
                            RegistrationPlate = "34-OBS-123",
                            SeatMapping = 1,
                            Year = 2015
                        },
                        new
                        {
                            BusId = 2,
                            BusModelId = 3,
                            DistanceTraveled = 10000,
                            RegistrationPlate = "17-ASS-562",
                            SeatMapping = 1,
                            Year = 2020
                        },
                        new
                        {
                            BusId = 3,
                            BusModelId = 3,
                            DistanceTraveled = 62000,
                            RegistrationPlate = "34-OBS-123",
                            SeatMapping = 3,
                            Year = 2013
                        },
                        new
                        {
                            BusId = 4,
                            BusModelId = 4,
                            DistanceTraveled = 2000,
                            RegistrationPlate = "34-OBS-123",
                            SeatMapping = 3,
                            Year = 2016
                        },
                        new
                        {
                            BusId = 5,
                            BusModelId = 5,
                            DistanceTraveled = 31000,
                            RegistrationPlate = "34-OBS-123",
                            SeatMapping = 2,
                            Year = 2018
                        },
                        new
                        {
                            BusId = 6,
                            BusModelId = 1,
                            DistanceTraveled = 7800,
                            RegistrationPlate = "34-FBS-123",
                            SeatMapping = 2,
                            Year = 2020
                        },
                        new
                        {
                            BusId = 7,
                            BusModelId = 2,
                            DistanceTraveled = 8000,
                            RegistrationPlate = "34-OBS-123",
                            SeatMapping = 1,
                            Year = 2013
                        });
                });

            modelBuilder.Entity("CloudTours.Domain.BusManuFacturer", b =>
                {
                    b.Property<int>("BusManuFacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("BusManuFacturerId");

                    b.ToTable("BusManuFacturers");

                    b.HasData(
                        new
                        {
                            BusManuFacturerId = 1,
                            Name = "Mercedes"
                        },
                        new
                        {
                            BusManuFacturerId = 2,
                            Name = "Man"
                        },
                        new
                        {
                            BusManuFacturerId = 3,
                            Name = "Neoplan"
                        },
                        new
                        {
                            BusManuFacturerId = 4,
                            Name = "Isuzu"
                        });
                });

            modelBuilder.Entity("CloudTours.Domain.BusModel", b =>
                {
                    b.Property<int>("BusModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusManuFacturerId")
                        .HasColumnType("int");

                    b.Property<string>("BusModelName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("HasToilet")
                        .HasColumnType("bit");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("BusModelId");

                    b.HasIndex("BusManuFacturerId");

                    b.ToTable("BusModels");

                    b.HasData(
                        new
                        {
                            BusModelId = 1,
                            BusManuFacturerId = 1,
                            BusModelName = "Mercedess Travego2",
                            HasToilet = true,
                            SeatCapacity = 44,
                            Type = 2
                        },
                        new
                        {
                            BusModelId = 2,
                            BusManuFacturerId = 2,
                            BusModelName = "Man-Fortuna",
                            HasToilet = true,
                            SeatCapacity = 0,
                            Type = 0
                        },
                        new
                        {
                            BusModelId = 3,
                            BusManuFacturerId = 1,
                            BusModelName = "Mercedess Travego1",
                            HasToilet = false,
                            SeatCapacity = 44,
                            Type = 2
                        },
                        new
                        {
                            BusModelId = 4,
                            BusManuFacturerId = 3,
                            BusModelName = "Starliner",
                            HasToilet = true,
                            SeatCapacity = 44,
                            Type = 2
                        },
                        new
                        {
                            BusModelId = 5,
                            BusManuFacturerId = 2,
                            BusModelName = "Man-Lions",
                            HasToilet = true,
                            SeatCapacity = 26,
                            Type = 1
                        },
                        new
                        {
                            BusModelId = 6,
                            BusManuFacturerId = 4,
                            BusModelName = "Citibus",
                            HasToilet = true,
                            SeatCapacity = 44,
                            Type = 2
                        },
                        new
                        {
                            BusModelId = 7,
                            BusManuFacturerId = 4,
                            BusModelName = "Citimark",
                            HasToilet = false,
                            SeatCapacity = 52,
                            Type = 2
                        },
                        new
                        {
                            BusModelId = 8,
                            BusManuFacturerId = 4,
                            BusModelName = "Novociti",
                            HasToilet = true,
                            SeatCapacity = 48,
                            Type = 2
                        });
                });

            modelBuilder.Entity("CloudTours.Domain.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "İstanbul"
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Ankara"
                        });
                });

            modelBuilder.Entity("CloudTours.Domain.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("StationId");

                    b.HasIndex("CityId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            StationId = 1,
                            CityId = 1,
                            StationName = "Haydarpasa"
                        },
                        new
                        {
                            StationId = 2,
                            CityId = 2,
                            StationName = "Aşti"
                        });
                });

            modelBuilder.Entity("CloudTours.Domain.Bus", b =>
                {
                    b.HasOne("CloudTours.Domain.BusModel", "BusModel")
                        .WithMany("BusList")
                        .HasForeignKey("BusModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusModel");
                });

            modelBuilder.Entity("CloudTours.Domain.BusModel", b =>
                {
                    b.HasOne("CloudTours.Domain.BusManuFacturer", "BusManuFacturer")
                        .WithMany("BusModels")
                        .HasForeignKey("BusManuFacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusManuFacturer");
                });

            modelBuilder.Entity("CloudTours.Domain.Station", b =>
                {
                    b.HasOne("CloudTours.Domain.City", "City")
                        .WithMany("Stations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CloudTours.Domain.BusManuFacturer", b =>
                {
                    b.Navigation("BusModels");
                });

            modelBuilder.Entity("CloudTours.Domain.BusModel", b =>
                {
                    b.Navigation("BusList");
                });

            modelBuilder.Entity("CloudTours.Domain.City", b =>
                {
                    b.Navigation("Stations");
                });
#pragma warning restore 612, 618
        }
    }
}
