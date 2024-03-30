using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maylzam_MVC_.Migrations
{
    public partial class taxi001_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Personal_Cardback",
                table: "TaxiDriver",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personal_Cardback",
                table: "TaxiDriver");
        }
    }
}
