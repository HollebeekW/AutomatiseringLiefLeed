using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class AddDatesToApplicationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfApplication",
                table: "Applications",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfissue",
                table: "Applications",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfApplication",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DateOfissue",
                table: "Applications");
        }
    }
}
