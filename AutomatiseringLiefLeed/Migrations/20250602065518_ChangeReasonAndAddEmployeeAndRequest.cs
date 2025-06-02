using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReasonAndAddEmployeeAndRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reasons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAnniversary",
                table: "Reasons",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "GiftAmount",
                table: "Reasons",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AnniversaryYears",
                table: "Reasons",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medewerker = table.Column<int>(type: "int", nullable: false),
                    Roepnaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailWerk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeboorteDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    AOWDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    InDienstIVMDienstJaren = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    DateOfApplication = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnniversaryYears",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 3,
                column: "AnniversaryYears",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnniversaryYears",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 5,
                column: "AnniversaryYears",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 8,
                column: "AnniversaryYears",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 9,
                column: "AnniversaryYears",
                value: 65.0);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 11,
                column: "AnniversaryYears",
                value: 12.5);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 13,
                column: "AnniversaryYears",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 14,
                column: "AnniversaryYears",
                value: 40.0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ReasonId",
                table: "Requests",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RecipientId",
                table: "Requests",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SenderId",
                table: "Requests",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAnniversary",
                table: "Reasons",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GiftAmount",
                table: "Reasons",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AnniversaryYears",
                table: "Reasons",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "DateOfApplication", "DateOfIssue", "IsAccepted", "ReasonId", "RecipientId", "SenderId" },
                values: new object[] { 2, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "user-bob", "user-bob" });

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
                keyValue: 11,
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

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "AnniversaryYears", "GiftAmount", "IsAnniversary", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, 25.0, true, "geboorte" },
                    { 6, 0.0, 40.0, true, "huwelijk/geregistreerd partnerschap" },
                    { 10, 0.0, 25.0, true, "12,5 jaar huwelijk" },
                    { 12, 0.0, 25.0, true, "25 jaar huwelijk" },
                    { 15, 0.0, 40.0, true, "40 jarig huwelijk" },
                    { 20, 0.0, 40.0, true, "Verjaardag" },
                    { 21, 0.0, 50.0, true, "Trouwen" },
                    { 101, 0.0, 250.0, false, "Marriage" },
                    { 102, 0.0, 150.0, false, "Birth" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "DateOfApplication", "DateOfIssue", "IsAccepted", "ReasonId", "RecipientId", "SenderId" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "user-alice", "user-alice" });
        }
    }
}
