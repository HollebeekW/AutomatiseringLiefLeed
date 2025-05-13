using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class ReasonSeedingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnniversary",
                table: "Reasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "Id", "IsAnniversary", "MoneyAmount", "Name" },
                values: new object[,]
                {
                    { 1, true, 25.0, "geboorte" },
                    { 2, false, 25.0, "ziek" },
                    { 3, false, 25.0, "ziekte 3 maanden" },
                    { 4, false, 25.0, "ziekte 3 weken" },
                    { 5, false, 25.0, "ziekte ziekenhuisopname" },
                    { 6, true, 40.0, "huwelijk/geregistreerd partnerschap" },
                    { 7, true, 25.0, "ontslag/fpu/pensionering" },
                    { 8, true, 25.0, "50e verjaardag" },
                    { 9, true, 25.0, "65e verjaardag" },
                    { 10, true, 25.0, "12,5 jaar huwelijk" },
                    { 11, true, 25.0, "12,5 jaar ambtenaar" },
                    { 12, true, 25.0, "25 jaar huwelijk" },
                    { 13, false, 50.0, "overlijden ambtenaar of huisgenoot" },
                    { 14, true, 40.0, "40 jaar ambtenaar" },
                    { 15, true, 40.0, "40 jarig huwelijk" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reasons",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "IsAnniversary",
                table: "Reasons");
        }
    }
}
