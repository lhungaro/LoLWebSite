using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolWebApiRest.Migrations
{
    public partial class RemovendoIdIcone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdIcone",
                table: "Duos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdIcone",
                table: "Duos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
