using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatiseringLiefLeed.Migrations
{
    /// <inheritdoc />
    public partial class FixKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "SenderId",
            table: "Applications",
            type: "int",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
