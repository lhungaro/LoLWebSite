using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolWebApiRest.Migrations
{
    public partial class AjusteDuo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdElo",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "IdLane",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "IdLaneDuo",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "IdModoDeJogo",
                table: "Duos");

            migrationBuilder.AddColumn<string>(
                name: "Elo",
                table: "Duos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lane",
                table: "Duos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LaneDuo",
                table: "Duos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModoDeJogo",
                table: "Duos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elo",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "Lane",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "LaneDuo",
                table: "Duos");

            migrationBuilder.DropColumn(
                name: "ModoDeJogo",
                table: "Duos");

            migrationBuilder.AddColumn<int>(
                name: "IdElo",
                table: "Duos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLane",
                table: "Duos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLaneDuo",
                table: "Duos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdModoDeJogo",
                table: "Duos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
