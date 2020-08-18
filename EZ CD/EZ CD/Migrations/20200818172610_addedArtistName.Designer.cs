﻿// <auto-generated />
using System;
using EZ_CD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EZ_CD.Migrations
{
    [DbContext(typeof(EZ_CDContext))]
    [Migration("20200818172610_addedArtistName")]
    partial class addedArtistName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EZ_CD.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("EZ_CD.Models.Artist", b =>
                {
                    b.Property<int>("artistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("artistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("EZ_CD.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EZ_CD.Models.Disk", b =>
                {
                    b.Property<int>("diskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("adminId")
                        .HasColumnType("int");

                    b.Property<int?>("artistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("diskId");

                    b.HasIndex("adminId");

                    b.HasIndex("artistId");

                    b.ToTable("Disk");
                });

            modelBuilder.Entity("EZ_CD.Models.Sale", b =>
                {
                    b.Property<int>("saleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("saleId");

                    b.HasIndex("customerId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("EZ_CD.Models.SaleDetailes", b =>
                {
                    b.Property<int>("diskId")
                        .HasColumnType("int");

                    b.Property<int>("saleId")
                        .HasColumnType("int");

                    b.HasKey("diskId", "saleId");

                    b.HasIndex("saleId");

                    b.ToTable("SaleDetailes");
                });

            modelBuilder.Entity("EZ_CD.Models.Song", b =>
                {
                    b.Property<int>("songId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("diskId")
                        .HasColumnType("int");

                    b.Property<string>("length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("songId");

                    b.HasIndex("diskId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("EZ_CD.Models.Disk", b =>
                {
                    b.HasOne("EZ_CD.Models.Admin", "admin")
                        .WithMany()
                        .HasForeignKey("adminId");

                    b.HasOne("EZ_CD.Models.Artist", "artist")
                        .WithMany("disks")
                        .HasForeignKey("artistId");
                });

            modelBuilder.Entity("EZ_CD.Models.Sale", b =>
                {
                    b.HasOne("EZ_CD.Models.Customer", "customer")
                        .WithMany("purchases")
                        .HasForeignKey("customerId");
                });

            modelBuilder.Entity("EZ_CD.Models.SaleDetailes", b =>
                {
                    b.HasOne("EZ_CD.Models.Disk", "disk")
                        .WithMany("disksSalesDetailes")
                        .HasForeignKey("diskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EZ_CD.Models.Sale", "sale")
                        .WithMany("disksSalesDetailes")
                        .HasForeignKey("saleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EZ_CD.Models.Song", b =>
                {
                    b.HasOne("EZ_CD.Models.Disk", "disk")
                        .WithMany("songs")
                        .HasForeignKey("diskId");
                });
#pragma warning restore 612, 618
        }
    }
}
