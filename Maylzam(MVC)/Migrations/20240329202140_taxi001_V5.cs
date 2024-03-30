using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maylzam_MVC_.Migrations
{
    public partial class taxi001_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Personal_Card",
                table: "TrafficPolice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Personal_Cardback",
                table: "TrafficPolice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personal_Card",
                table: "TrafficPolice");

            migrationBuilder.DropColumn(
                name: "Personal_Cardback",
                table: "TrafficPolice");
        }
    }
}
