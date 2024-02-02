using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freela.Persistence.Migrations
{
    public partial class mudancauserproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "contaxt");

            migrationBuilder.RenameColumn(
                name: "DurationTime",
                table: "Projects",
                newName: "categories");

            migrationBuilder.AddColumn<string>(
                name: "Curriculum",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Proposes",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValueToPay",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Proposes",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ValueToPay",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "contaxt",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categories",
                table: "Projects",
                newName: "DurationTime");
        }
    }
}
