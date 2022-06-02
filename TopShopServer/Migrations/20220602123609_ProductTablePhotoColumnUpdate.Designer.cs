﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopShopServer.Models;

#nullable disable

namespace TopShopServer.Migrations
{
    [DbContext(typeof(TopShopContext))]
    [Migration("20220602123609_ProductTablePhotoColumnUpdate")]
    partial class ProductTablePhotoColumnUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("TopShopServer.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9243),
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9251),
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9252),
                            Name = "Puma"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9253),
                            Name = "Peacful Hooligan"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9254),
                            Name = "The North Face"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9254),
                            Name = "Alpha Industries"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9255),
                            Name = "Stone Island"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9256),
                            Name = "Polo Ralph Lauren"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9257),
                            Name = "Tommy Jeans"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9257),
                            Name = "thisisneverthat"
                        });
                });

            modelBuilder.Entity("TopShopServer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9336),
                            Name = "Sneakers"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9364),
                            Name = "Hoodies"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9365),
                            Name = "T-shirt"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9366),
                            Name = "Jackets"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9367),
                            Name = "Jeans"
                        });
                });

            modelBuilder.Entity("TopShopServer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Article = "20943",
                            BrandId = 1,
                            CategoryId = 1,
                            Code = "332-847",
                            CreatedAt = new DateTime(2022, 6, 2, 15, 36, 8, 777, DateTimeKind.Local).AddTicks(9399),
                            Description = "Nike its a best brand in sneakers category",
                            Photo = "some.jpg",
                            Price = 124.55m,
                            Title = "ACG Air Mada"
                        });
                });

            modelBuilder.Entity("TopShopServer.Models.ProductSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SizeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProductSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            SizeId = 5
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 1,
                            SizeId = 6
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 1,
                            SizeId = 7
                        });
                });

            modelBuilder.Entity("TopShopServer.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "S"
                        },
                        new
                        {
                            Id = 2,
                            Name = "M"
                        },
                        new
                        {
                            Id = 3,
                            Name = "L"
                        },
                        new
                        {
                            Id = 4,
                            Name = "XL"
                        },
                        new
                        {
                            Id = 5,
                            Name = "40"
                        },
                        new
                        {
                            Id = 6,
                            Name = "41"
                        },
                        new
                        {
                            Id = 7,
                            Name = "42"
                        });
                });

            modelBuilder.Entity("TopShopServer.Models.Product", b =>
                {
                    b.HasOne("TopShopServer.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopShopServer.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}