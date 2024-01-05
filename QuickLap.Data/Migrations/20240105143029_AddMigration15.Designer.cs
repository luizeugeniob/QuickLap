﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuickLap.Data.Context;

#nullable disable

namespace QuickLap.Data.Migrations
{
    [DbContext(typeof(QuickLapContext))]
    [Migration("20240105143029_AddMigration15")]
    partial class AddMigration15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuickLap.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateTime1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("QuickLap.Data.Entities.EntityOne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("String1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("String2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("EntityOnes", (string)null);
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateTime1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Int1")
                        .HasColumnType("integer");

                    b.Property<int?>("Int2")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("QuickLap.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Bool1")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateTime1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateTime2Changed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Int1")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("String1")
                        .HasColumnType("text");

                    b.Property<string>("String2Changed")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("QuickLap.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateTime1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Decimal1")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Decimal2")
                        .HasColumnType("numeric");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("Int1")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("QuickLap.Data.Entities.EntityOne", b =>
                {
                    b.HasOne("QuickLap.Data.Entities.Customer", null)
                        .WithMany("EntityOnes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Order", b =>
                {
                    b.HasOne("QuickLap.Data.Entities.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickLap.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("QuickLap.Data.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickLap.Data.Entities.Product", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Customer", b =>
                {
                    b.Navigation("EntityOnes");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("QuickLap.Data.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
