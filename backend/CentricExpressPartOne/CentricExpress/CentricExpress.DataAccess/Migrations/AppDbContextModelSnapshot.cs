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
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentricExpress.Business.Domain.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Item");
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
#pragma warning restore 612, 618
        }
    }
}