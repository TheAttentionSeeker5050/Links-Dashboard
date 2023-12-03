﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppProject3.Data;

#nullable disable

namespace WebAppProject3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231203015604_Mig5")]
    partial class Mig5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAppProject3.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebAppProject3.Models.LinkModel", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FaviconSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LinkCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("LinkHref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LinkLabel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LinkName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LinkId");

                    b.HasIndex("LinkCategoryCategoryId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("WebAppProject3.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordConfirmation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAppProject3.Models.LinkModel", b =>
                {
                    b.HasOne("WebAppProject3.Models.CategoryModel", "LinkCategory")
                        .WithMany()
                        .HasForeignKey("LinkCategoryCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
