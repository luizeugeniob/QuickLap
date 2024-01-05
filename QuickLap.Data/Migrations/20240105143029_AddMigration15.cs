using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime2",
                table: "OrderItem",
                newName: "DateTime2Changed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime2Changed",
                table: "OrderItem",
                newName: "DateTime2");
        }
    }
}
