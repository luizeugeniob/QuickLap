﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLap.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "EntityOnes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntityOnes_CustomerId",
                table: "EntityOnes",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityOnes_Customers_CustomerId",
                table: "EntityOnes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityOnes_Customers_CustomerId",
                table: "EntityOnes");

            migrationBuilder.DropIndex(
                name: "IX_EntityOnes_CustomerId",
                table: "EntityOnes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "EntityOnes");
        }
    }
}
