﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektZaliczeniowy.Data;

#nullable disable

namespace ProjektZaliczeniowy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalIssues");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalIssueDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExternalIssueId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalIssueId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExternalIssueDetails");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalReceipts");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalReceiptDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExternalReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalReceiptId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExternalReceiptDetails");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("InternalIssues");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalIssueDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InternalIssueId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InternalIssueId");

                    b.HasIndex("ProductId");

                    b.ToTable("InternalIssueDetails");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("InternalReceipts");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalReceiptDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InternalReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InternalReceiptId");

                    b.HasIndex("ProductId");

                    b.ToTable("InternalReceiptDetails");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CatalogNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ean")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("QuantityInStock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalIssue", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.User", "User")
                        .WithMany("ExternalIssues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalIssueDetail", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.ExternalIssue", "ExternalIssue")
                        .WithMany("Details")
                        .HasForeignKey("ExternalIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowy.Models.Entities.Product", "Product")
                        .WithMany("ExternalIssueDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExternalIssue");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalReceipt", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.User", "User")
                        .WithMany("ExternalReceipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalReceiptDetail", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.ExternalReceipt", "ExternalReceipt")
                        .WithMany("Details")
                        .HasForeignKey("ExternalReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowy.Models.Entities.Product", "Product")
                        .WithMany("ExternalReceiptDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExternalReceipt");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalIssue", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.User", "User")
                        .WithMany("InternalIssues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalIssueDetail", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.InternalIssue", "InternalIssue")
                        .WithMany("Details")
                        .HasForeignKey("InternalIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowy.Models.Entities.Product", "Product")
                        .WithMany("InternalIssueDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InternalIssue");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalReceipt", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.User", "User")
                        .WithMany("InternalReceipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalReceiptDetail", b =>
                {
                    b.HasOne("ProjektZaliczeniowy.Models.Entities.InternalReceipt", "InternalReceipt")
                        .WithMany("Details")
                        .HasForeignKey("InternalReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowy.Models.Entities.Product", "Product")
                        .WithMany("InternalReceiptDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InternalReceipt");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalIssue", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.ExternalReceipt", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalIssue", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.InternalReceipt", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.Product", b =>
                {
                    b.Navigation("ExternalIssueDetails");

                    b.Navigation("ExternalReceiptDetails");

                    b.Navigation("InternalIssueDetails");

                    b.Navigation("InternalReceiptDetails");
                });

            modelBuilder.Entity("ProjektZaliczeniowy.Models.Entities.User", b =>
                {
                    b.Navigation("ExternalIssues");

                    b.Navigation("ExternalReceipts");

                    b.Navigation("InternalIssues");

                    b.Navigation("InternalReceipts");
                });
#pragma warning restore 612, 618
        }
    }
}
