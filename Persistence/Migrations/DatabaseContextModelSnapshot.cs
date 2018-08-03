﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Shared;

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new { Id = 2, LastModified = new DateTime(2018, 7, 30, 9, 2, 12, 769, DateTimeKind.Local), Name = "TestCustomer", PhoneNumber = 7L }
                    );
                });

            modelBuilder.Entity("Domain.Partners.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Partners");

                    b.HasData(
                        new { Id = 3, LastModified = new DateTime(2018, 7, 30, 9, 2, 12, 771, DateTimeKind.Local), Name = "TestPartner", PhoneNumber = 7L }
                    );
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, LastModified = new DateTime(2018, 7, 30, 9, 2, 12, 776, DateTimeKind.Local), Name = "TestProduct", UnitPrice = 3m },
                        new { Id = 2, LastModified = new DateTime(2018, 7, 29, 9, 2, 12, 776, DateTimeKind.Local), Name = "TestProduct2", UnitPrice = 2m }
                    );
                });

            modelBuilder.Entity("Domain.Sales.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("LastModified");

                    b.Property<int?>("PartnerId");

                    b.Property<decimal>("TotalSalePrice")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Sales");

                    b.HasData(
                        new { Id = 1, CustomerId = 2, Date = new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), LastModified = new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), PartnerId = 3, TotalSalePrice = 7m }
                    );
                });

            modelBuilder.Entity("Domain.Sales.SaleProduct", b =>
                {
                    b.Property<int>("SaleId");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalProductPrice");

                    b.HasKey("SaleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleProduct");

                    b.HasData(
                        new { SaleId = 1, ProductId = 1, LastModified = new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local), Quantity = 1, TotalProductPrice = 3m },
                        new { SaleId = 1, ProductId = 2, LastModified = new DateTime(2018, 7, 30, 9, 2, 12, 789, DateTimeKind.Local), Quantity = 2, TotalProductPrice = 4m }
                    );
                });

            modelBuilder.Entity("Domain.Sales.Sale", b =>
                {
                    b.HasOne("Domain.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.Partners.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId");
                });

            modelBuilder.Entity("Domain.Sales.SaleProduct", b =>
                {
                    b.HasOne("Domain.Products.Product", "Product")
                        .WithMany("SaleProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Sales.Sale", "Sale")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}