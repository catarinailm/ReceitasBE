using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReceitasBE.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c316fd3-3daf-48c7-8549-449f5253684c"), "Bebidas" },
                    { new Guid("1b136692-f806-45b1-9812-4e7bd8609a4e"), "Petiscos" },
                    { new Guid("1cb49a78-e9fb-421c-87d3-a8d863936cf0"), "Refeições" },
                    { new Guid("65330e3f-1929-466b-9aea-bbb9e8aa6134"), "Light" },
                    { new Guid("8710397d-1de5-45fd-9122-17cd0b9cf00e"), "Sobremesas" },
                    { new Guid("a58f8085-5c6b-4c93-a6df-589f902a3a7e"), "Entradas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0c316fd3-3daf-48c7-8549-449f5253684c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1b136692-f806-45b1-9812-4e7bd8609a4e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1cb49a78-e9fb-421c-87d3-a8d863936cf0"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("65330e3f-1929-466b-9aea-bbb9e8aa6134"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("8710397d-1de5-45fd-9122-17cd0b9cf00e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a58f8085-5c6b-4c93-a6df-589f902a3a7e"));
        }
    }
}
