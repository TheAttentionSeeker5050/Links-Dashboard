using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProject3.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaviconPath",
                table: "Links",
                newName: "FaviconSrc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaviconSrc",
                table: "Links",
                newName: "FaviconPath");
        }
    }
}
