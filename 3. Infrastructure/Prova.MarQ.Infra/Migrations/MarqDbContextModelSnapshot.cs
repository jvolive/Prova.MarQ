﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prova.MarQ.Infra;

#nullable disable

namespace Prova.MarQ.Infra.Migrations
{
    [DbContext(typeof(MarqDbContext))]
    partial class MarqDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Prova.MarQ.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Prova.MarQ.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PinHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PinSalt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registration")
                        .HasMaxLength(6)
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Prova.MarQ.Domain.Entities.TimeRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeRegistration")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<double>("OvertimeHours")
                        .HasColumnType("REAL");

                    b.Property<string>("PinUsed")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalHours")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("WorkedHours")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TimeRecords");
                });

            modelBuilder.Entity("Prova.MarQ.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Prova.MarQ.Domain.Entities.Company", null)
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Prova.MarQ.Domain.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
