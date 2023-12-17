using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceitasBE.Migrations
{
    /// <inheritdoc />
    public partial class Removedate_updatefromcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_updated",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "Comment",
                newName: "Deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Comment",
                newName: "deleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_updated",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
