﻿// <auto-generated />
using System;
using Bulk.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulk.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulk.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("Bulk.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<double?>("Price2")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<double?>("PriceMoreThan10")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Brand Name-1",
                            CategoryId = 1,
                            Description = "Description-1",
                            ImageUrl = "",
                            Price = 50.0,
                            Price2 = 45.0,
                            PriceMoreThan10 = 40.0,
                            SKU = "SKU-1",
                            Title = "Title-1"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "Brand Name-2",
                            CategoryId = 1,
                            Description = "Description-2",
                            ImageUrl = "",
                            Price = 5.0,
                            Price2 = 4.5,
                            PriceMoreThan10 = 4.0,
                            SKU = "SKU-2",
                            Title = "Title-2"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "Brand Name-3",
                            CategoryId = 1,
                            Description = "Description-3",
                            ImageUrl = "",
                            Price = 25.0,
                            Price2 = 20.0,
                            PriceMoreThan10 = 15.0,
                            SKU = "SKU-3",
                            Title = "Title-3"
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "Brand Name-4",
                            CategoryId = 1,
                            Description = "Description-4",
                            ImageUrl = "",
                            Price = 75.0,
                            Price2 = 70.0,
                            PriceMoreThan10 = 65.0,
                            SKU = "SKU-4",
                            Title = "Title-4"
                        },
                        new
                        {
                            Id = 5,
                            BrandName = "Brand Name-5",
                            CategoryId = 2,
                            Description = "Description-5",
                            ImageUrl = "",
                            Price = 15.0,
                            Price2 = 10.0,
                            PriceMoreThan10 = 7.5,
                            SKU = "SKU-5",
                            Title = "Title-5"
                        },
                        new
                        {
                            Id = 6,
                            BrandName = "Brand Name-6",
                            CategoryId = 2,
                            Description = "Description-6",
                            ImageUrl = "",
                            Price = 150.0,
                            Price2 = 120.0,
                            PriceMoreThan10 = 99.0,
                            SKU = "SKU-6",
                            Title = "Title-6"
                        },
                        new
                        {
                            Id = 7,
                            BrandName = "Brand Name-7",
                            CategoryId = 2,
                            Description = "Description-7",
                            ImageUrl = "",
                            Price = 255.0,
                            Price2 = 230.0,
                            PriceMoreThan10 = 210.0,
                            SKU = "SKU-7",
                            Title = "Title-7"
                        },
                        new
                        {
                            Id = 8,
                            BrandName = "Brand Name-8",
                            CategoryId = 3,
                            Description = "Description-8",
                            ImageUrl = "",
                            Price = 344.0,
                            Price2 = 320.0,
                            PriceMoreThan10 = 280.0,
                            SKU = "SKU-8",
                            Title = "Title-8"
                        },
                        new
                        {
                            Id = 9,
                            BrandName = "Brand Name-9",
                            CategoryId = 3,
                            Description = "Description-9",
                            ImageUrl = "",
                            Price = 9.0,
                            Price2 = 7.0,
                            PriceMoreThan10 = 4.0,
                            SKU = "SKU-9",
                            Title = "Title-9"
                        },
                        new
                        {
                            Id = 10,
                            BrandName = "Brand Name-10",
                            CategoryId = 3,
                            Description = "Description-10",
                            ImageUrl = "",
                            Price = 500.0,
                            Price2 = 450.0,
                            PriceMoreThan10 = 400.0,
                            SKU = "SKU-10",
                            Title = "Title-10"
                        });
                });

            modelBuilder.Entity("Bulk.Models.Product", b =>
                {
                    b.HasOne("Bulk.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
