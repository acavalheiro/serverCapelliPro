﻿// <auto-generated />
using System;
using CapelliPro.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapelliPro.Domain.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210311141829_ImageCapillarTable")]
    partial class ImageCapillarTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CapelliPro.Domain.Models.Diagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Disease")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Solution")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Diagnostics");
                });

            modelBuilder.Entity("CapelliPro.Domain.Models.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Data2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Examples");
                });

            modelBuilder.Entity("CapelliPro.Domain.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DesiredHair")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HairColour")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HairType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HasColouredHair")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LivingPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NumberWashes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UseHeatTools")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UseThermalProducts")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
