using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bool1",
                table: "EntityOnes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime1",
                table: "EntityOnes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bool1",
                table: "EntityOnes");

            migrationBuilder.DropColumn(
                name: "DateTime1",
                table: "EntityOnes");
        }
    }
}
