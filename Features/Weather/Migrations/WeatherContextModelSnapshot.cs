﻿// <auto-generated />
using System;
using Jtbuk.VerticalArchitecture.Features.Weather;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jtbuk.VerticalArchitecture.Features.Weather.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Jtbuk.VerticalArchitecture.Features.Weather.Entities.WeatherReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("Precipitation")
                        .HasColumnType("int");

                    b.Property<double>("TemperatureInCelcius")
                        .HasColumnType("float");

                    b.Property<int>("WindMph")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherReports");
                });
#pragma warning restore 612, 618
        }
    }
}
