using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Product.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Color", "Price", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("2acc6af2-de67-4a57-be47-916f67d089ae"), "Red", 100000.0, "پیراهن", "TShirt" },
                    { new Guid("3e523694-90c4-4ba0-961c-a9a7c41821aa"), "Blue", 70000000.0, "کامپیوتر سامسونگ", "Computer" },
                    { new Guid("76a86c32-7052-4539-b062-fa947bd4a134"), "Blue", 40000000.0, "موبایل اپل", "Mobile" },
                    { new Guid("7eea17e9-03b7-455c-a48c-601c21c4a391"), "Blue", 100000000.0, "کامپیوتر اپل", "Computer" },
                    { new Guid("a8cb94a6-bd12-46e0-8810-1d5231fff662"), "Red", 4000000.0, "موبایل ایسوز", "Mobile" },
                    { new Guid("ae38dde3-61a2-4df2-b5bc-7dae0abca126"), "Green", 40000000.0, "کامپیوتر ایسوز", "Computer" },
                    { new Guid("b8dbbb81-dcc6-459e-951e-0bb38457e80d"), "Green", 5000000.0, "موبایل سامسونگ", "Mobile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
