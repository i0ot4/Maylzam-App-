using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maylzam_MVC_.Migrations
{
    public partial class taxi001_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VNumber",
                table: "TaxiDriverVechicle",
                newName: "vehicleLicenseCardImage");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "TaxiDriverVechicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "licensePlateNumber",
                table: "TaxiDriverVechicle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "TaxiDriverVechicle");

            migrationBuilder.DropColumn(
                name: "licensePlateNumber",
                table: "TaxiDriverVechicle");

            migrationBuilder.RenameColumn(
                name: "vehicleLicenseCardImage",
                table: "TaxiDriverVechicle",
                newName: "VNumber");
        }
    }
}
