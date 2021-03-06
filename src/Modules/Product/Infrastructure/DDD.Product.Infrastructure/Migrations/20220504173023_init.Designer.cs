// <auto-generated />
using System;
using DDD.Product.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Product.Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20220504173023_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DDD.Product.Domain.Product.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7eea17e9-03b7-455c-a48c-601c21c4a391"),
                            Color = "Blue",
                            Price = 100000000.0,
                            Title = "کامپیوتر اپل",
                            Type = "Computer"
                        },
                        new
                        {
                            Id = new Guid("3e523694-90c4-4ba0-961c-a9a7c41821aa"),
                            Color = "Blue",
                            Price = 70000000.0,
                            Title = "کامپیوتر سامسونگ",
                            Type = "Computer"
                        },
                        new
                        {
                            Id = new Guid("ae38dde3-61a2-4df2-b5bc-7dae0abca126"),
                            Color = "Green",
                            Price = 40000000.0,
                            Title = "کامپیوتر ایسوز",
                            Type = "Computer"
                        },
                        new
                        {
                            Id = new Guid("a8cb94a6-bd12-46e0-8810-1d5231fff662"),
                            Color = "Red",
                            Price = 4000000.0,
                            Title = "موبایل ایسوز",
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("b8dbbb81-dcc6-459e-951e-0bb38457e80d"),
                            Color = "Green",
                            Price = 5000000.0,
                            Title = "موبایل سامسونگ",
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("76a86c32-7052-4539-b062-fa947bd4a134"),
                            Color = "Blue",
                            Price = 40000000.0,
                            Title = "موبایل اپل",
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("2acc6af2-de67-4a57-be47-916f67d089ae"),
                            Color = "Red",
                            Price = 100000.0,
                            Title = "پیراهن",
                            Type = "TShirt"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
