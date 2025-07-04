﻿// <auto-generated />
using CashFlow.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashFlow.Infrastructure.Migrations
{
    [DbContext(typeof(CashFlowDbContext))]
    [Migration("20250527232147_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CashFlow.Domain.Entity.CashFlowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Increment")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CashFlow", (string)null);
                });

            modelBuilder.Entity("CashFlow.Domain.Entity.CashFlowEntity", b =>
                {
                    b.OwnsOne("Shared.Domain.ValueObjects.DiscountRates", "DiscountRates", b1 =>
                        {
                            b1.Property<int>("CashFlowEntityId")
                                .HasColumnType("int");

                            b1.Property<double>("LowerBound")
                                .HasColumnType("float");

                            b1.Property<double>("UpperBound")
                                .HasColumnType("float");

                            b1.HasKey("CashFlowEntityId");

                            b1.ToTable("CashFlow");

                            b1.WithOwner()
                                .HasForeignKey("CashFlowEntityId");
                        });

                    b.Navigation("DiscountRates")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
