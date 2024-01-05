using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "String1",
                table: "EntityOnes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "String2",
                table: "EntityOnes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "String1",
                table: "EntityOnes");

            migrationBuilder.DropColumn(
                name: "String2",
                table: "EntityOnes");
        }
    }
}
