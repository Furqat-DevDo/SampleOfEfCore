using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Migrations
{
    /// <inheritdoc />
    public partial class SecondDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products",
                table: "Storages");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Stuffs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Storages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "ProductIds",
                table: "Storages",
                type: "jsonb",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageSrc = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    ManufacturedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ProductId",
                table: "Storages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Product_ProductId",
                table: "Storages",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Product_ProductId",
                table: "Storages");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Storages_ProductId",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Stuffs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Storages");

            migrationBuilder.AddColumn<List<int>>(
                name: "Products",
                table: "Storages",
                type: "integer[]",
                nullable: false);
        }
    }
}
