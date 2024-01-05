using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime1",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Int1",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Int1",
                table: "Users");
        }
    }
}
