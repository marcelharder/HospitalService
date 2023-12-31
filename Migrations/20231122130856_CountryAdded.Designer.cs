﻿// <auto-generated />
using HospitalService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231122130856_CountryAdded")]
    partial class CountryAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HospitalService.Data.Entities.ClassCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("IsoCode")
                        .HasColumnType("longtext");

                    b.Property<int>("TelCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HospitalService.Data.Entities.Class_Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext");

                    b.Property<string>("Contact_image")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("DBBackend")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Fax")
                        .HasColumnType("longtext");

                    b.Property<string>("HospitalName")
                        .HasColumnType("longtext");

                    b.Property<string>("HospitalNo")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails1")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails2")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails3")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails4")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails5")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails6")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails7")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails8")
                        .HasColumnType("longtext");

                    b.Property<string>("OpReportDetails9")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("RefHospitals")
                        .HasColumnType("longtext");

                    b.Property<string>("RegExpr")
                        .HasColumnType("longtext");

                    b.Property<string>("Rp")
                        .HasColumnType("longtext");

                    b.Property<string>("SMSMobileNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("SMSSendTime")
                        .HasColumnType("longtext");

                    b.Property<string>("SampleMrn")
                        .HasColumnType("longtext");

                    b.Property<string>("SelectedHospitalName")
                        .HasColumnType("longtext");

                    b.Property<string>("StandardRef")
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .HasColumnType("longtext");

                    b.Property<bool>("TriggerOneMonth")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TriggerThreeMonth")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TriggerTwoMonth")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("UsesOnlineValveInventory")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Vendors")
                        .HasColumnType("longtext");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
