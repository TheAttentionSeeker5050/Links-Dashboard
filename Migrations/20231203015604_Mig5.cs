using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProject3.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Categories_CategoryId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Links",
                newName: "LinkCategoryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_CategoryId",
                table: "Links",
                newName: "IX_Links_LinkCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Categories_LinkCategoryCategoryId",
                table: "Links",
                column: "LinkCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Categories_LinkCategoryCategoryId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "LinkCategoryCategoryId",
                table: "Links",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_LinkCategoryCategoryId",
                table: "Links",
                newName: "IX_Links_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Categories_CategoryId",
                table: "Links",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
