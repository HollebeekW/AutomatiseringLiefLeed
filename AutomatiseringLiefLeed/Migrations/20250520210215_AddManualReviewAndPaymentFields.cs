using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class AddManualReviewAndPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiresManualReview",
                table: "Requests",
                newName: "PaymentApproved");

            migrationBuilder.RenameColumn(
                name: "PaymentProcessed",
                table: "Requests",
                newName: "ManualReviewRequired");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "EventPrice", "IsAnniversary", "Name" },
                values: new object[,]
                {
                    { 20, 40.0, true, "Verjaardag" },
                    { 21, 50.0, true, "Trouwen" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "EmployeeName", "EventType", "ManualReviewRequired", "Note", "PaymentApproved", "RequestDate", "Status" },
                values: new object[,]
                {
                    { 1, "Alice Example", "Marriage", false, "Voorbeeldaanvraag", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Bob Test", "Birth", true, "Spoed", false, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "PaymentApproved",
                table: "Requests",
                newName: "RequiresManualReview");

            migrationBuilder.RenameColumn(
                name: "ManualReviewRequired",
                table: "Requests",
                newName: "PaymentProcessed");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
