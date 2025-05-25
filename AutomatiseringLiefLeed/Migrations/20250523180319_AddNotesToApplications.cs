using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesToApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Requests_RequestId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "RecipientName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "EventPrice",
                table: "Reasons",
                newName: "GiftAmount");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Notes",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_RequestId",
                table: "Notes",
                newName: "IX_Notes_ApplicationId");

            migrationBuilder.AddColumn<double>(
                name: "AnniversaryYears",
                table: "Reasons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "DateOfApplication", "DateOfIssue", "IsAccepted", "ReasonId", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "user-alice", "user-alice" },
                    { 2, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "user-bob", "user-bob" }
                });

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 3,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 5,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 6,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 7,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 8,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 9,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 10,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 11,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 12,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 13,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 14,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 15,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 20,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 21,
                column: "AnniversaryYears",
                value: 0.0);

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "AnniversaryYears", "GiftAmount", "IsAnniversary", "Name" },
                values: new object[,]
                {
                    { 101, 0.0, 250.0, false, "Marriage" },
                    { 102, 0.0, 150.0, false, "Birth" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Applications_ApplicationId",
                table: "Notes",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Applications_ApplicationId",
                table: "Notes");

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DropColumn(
                name: "AnniversaryYears",
                table: "Reasons");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "GiftAmount",
                table: "Reasons",
                newName: "EventPrice");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Notes",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ApplicationId",
                table: "Notes",
                newName: "IX_Notes_RequestId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecipientName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManualReviewRequired = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentApproved = table.Column<bool>(type: "bit", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "EmployeeName", "EventType", "ManualReviewRequired", "Note", "PaymentApproved", "RequestDate", "Status" },
                values: new object[,]
                {
                    { 1, "Alice Example", "Marriage", false, "Voorbeeldaanvraag", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 2, "Bob Test", "Birth", true, "Spoed", false, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Requests_RequestId",
                table: "Notes",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
