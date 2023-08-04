using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Migrations
{
    /// <inheritdoc />
    public partial class SecondDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Storages");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Stuffs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Storages",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Shops",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Companies",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CategoriesImages",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Stuffs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<List<int>>(
                name: "ProductIds",
                table: "Storages",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Storages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ProductsId",
                table: "Storages",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesImages_CategoryId",
                table: "CategoriesImages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesImages_Categories_CategoryId",
                table: "CategoriesImages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Products_ProductsId",
                table: "Storages",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesImages_Categories_CategoryId",
                table: "CategoriesImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Products_ProductsId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_Storages_ProductsId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesImages_CategoryId",
                table: "CategoriesImages");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Stuffs");

            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Storages");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Stuffs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Storages",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Shops",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Companies",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CategoriesImages",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.AddColumn<List<int>>(
                name: "ProductId",
                table: "Storages",
                type: "integer[]",
                nullable: false);
        }
    }
}
