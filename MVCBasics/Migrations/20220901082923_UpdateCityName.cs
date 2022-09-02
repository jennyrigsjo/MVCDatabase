using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBasics.Migrations
{
    public partial class UpdateCityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Göteborg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Stockholm");
        }
    }
}
