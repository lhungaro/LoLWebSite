using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freela.Persistence.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Areas",
                table: "Users",
                newName: "Area");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Users",
                newName: "Areas");
        }
    }
}
