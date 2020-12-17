using Microsoft.EntityFrameworkCore.Migrations;

namespace BMWCarsAndParts.Data.Migrations
{
    public partial class AddColumnsInSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");
        }
    }
}
