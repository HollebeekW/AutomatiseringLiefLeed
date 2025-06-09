using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationModelRelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Applications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfApplication",
                table: "Applications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_RecipientId",
                table: "Applications",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Employees_RecipientId",
                table: "Applications",
                column: "RecipientId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Employees_RecipientId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_RecipientId",
                table: "Applications");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfApplication",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
