using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LolWebApiRest.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLane = table.Column<int>(type: "int", nullable: false),
                    IdLaneDuo = table.Column<int>(type: "int", nullable: false),
                    IdElo = table.Column<int>(type: "int", nullable: false),
                    IdModoDeJogo = table.Column<int>(type: "int", nullable: false),
                    IsVoiceUser = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duos");
        }
    }
}
