using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProject3.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkPath",
                table: "Links",
                newName: "LinkLabel");

            migrationBuilder.AddColumn<string>(
                name: "LinkHref",
                table: "Links",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkHref",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "LinkLabel",
                table: "Links",
                newName: "LinkPath");
        }
    }
}
