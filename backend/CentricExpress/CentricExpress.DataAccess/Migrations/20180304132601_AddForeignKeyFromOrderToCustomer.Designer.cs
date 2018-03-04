﻿// <auto-generated />
using CentricExpress.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CentricExpress.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180304132601_AddForeignKeyFromOrderToCustomer")]
    partial class AddForeignKeyFromOrderToCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentricExpress.Business.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.CustomerPoints", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<int>("Points");

                    b.HasKey("OrderId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000);

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ItemId");

                    b.Property<Guid?>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.Item", b =>
                {
                    b.OwnsOne("CentricExpress.Business.Domain.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ItemId");

                            b1.Property<string>("Currency");

                            b1.Property<decimal>("Value");

                            b1.ToTable("Item");

                            b1.HasOne("CentricExpress.Business.Domain.Item")
                                .WithOne("Price")
                                .HasForeignKey("CentricExpress.Business.Domain.Money", "ItemId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.Order", b =>
                {
                    b.HasOne("CentricExpress.Business.Domain.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CentricExpress.Business.Domain.OrderLine", b =>
                {
                    b.HasOne("CentricExpress.Business.Domain.Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("CentricExpress.Business.Domain.Money", "Price", b1 =>
                        {
                            b1.Property<Guid?>("OrderLineId");

                            b1.Property<string>("Currency");

                            b1.Property<decimal>("Value");

                            b1.ToTable("OrderLine");

                            b1.HasOne("CentricExpress.Business.Domain.OrderLine")
                                .WithOne("Price")
                                .HasForeignKey("CentricExpress.Business.Domain.Money", "OrderLineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}