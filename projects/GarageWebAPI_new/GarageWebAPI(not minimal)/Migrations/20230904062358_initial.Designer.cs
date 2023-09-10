﻿// <auto-generated />
using System;
using GarageWebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageWebAPI_not_minimal_.Migrations
{
    [DbContext(typeof(GarageContext))]
    [Migration("20230904062358_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GarageWebAPI.Garage", b =>
                {
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GarageId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GarageId");

                    b.ToTable("Garages");
                });

            modelBuilder.Entity("GarageWebAPI.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<int?>("GarageId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("GarageId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("GarageWebAPI.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("GarageWorker", b =>
                {
                    b.Property<int>("GaragesGarageId")
                        .HasColumnType("int");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("int");

                    b.HasKey("GaragesGarageId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("GarageWorker");
                });

            modelBuilder.Entity("VehicleWorker", b =>
                {
                    b.Property<int>("VehiclesVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("int");

                    b.HasKey("VehiclesVehicleId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("VehicleWorker");
                });

            modelBuilder.Entity("GarageWebAPI.Vehicle", b =>
                {
                    b.HasOne("GarageWebAPI.Garage", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("GarageId");
                });

            modelBuilder.Entity("GarageWorker", b =>
                {
                    b.HasOne("GarageWebAPI.Garage", null)
                        .WithMany()
                        .HasForeignKey("GaragesGarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageWebAPI.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleWorker", b =>
                {
                    b.HasOne("GarageWebAPI.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageWebAPI.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GarageWebAPI.Garage", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
