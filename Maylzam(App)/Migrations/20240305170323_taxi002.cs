using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maylzam_App_.Migrations
{
    public partial class taxi002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "worked",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "worked",
                table: "customers");
        }
    }
}
