﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Shared;

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180711155013_seed-test-data")]
    partial class seedtestdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new { Id = 2, Name = "TestCustomer", PhoneNumber = 7L }
                    );
                });

            modelBuilder.Entity("Domain.Partners.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Partners");

                    b.HasData(
                        new { Id = 3, Name = "TestPartner", PhoneNumber = 7L }
                    );
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 4, Name = "TestProduct", Price = 3m }
                    );
                });

            modelBuilder.Entity("Domain.Sales.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PartnerId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");

                    b.HasData(
                        new { Id = 1, CustomerId = 2, Date = new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), PartnerId = 3, ProductId = 4, Quantity = 1, TotalPrice = 3m, UnitPrice = 5m }
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

                    b.HasOne("Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
