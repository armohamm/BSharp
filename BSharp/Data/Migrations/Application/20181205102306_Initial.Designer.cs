﻿// <auto-generated />
using System;
using BSharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BSharp.Data.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181205102306_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BSharp.Data.Model.Application.MeasurementUnit", b =>
                {
                    b.Property<int>("TenantId");

                    b.Property<int>("Id");

                    b.Property<double>("BaseAmount");

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .IsRequired();

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name2")
                        .HasMaxLength(255);

                    b.Property<double>("UnitAmount");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TenantId", "Id");

                    b.ToTable("MeasurementUnits");
                });

            modelBuilder.Entity("BSharp.Data.Model.Application.Translation", b =>
                {
                    b.Property<int>("TenantId");

                    b.Property<string>("Culture")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Tier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2048);

                    b.HasKey("TenantId", "Culture", "Name");

                    b.ToTable("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
