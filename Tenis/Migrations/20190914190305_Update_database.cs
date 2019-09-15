using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class Update_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldToGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldIdId = table.Column<int>(nullable: true),
                    GameIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldToGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldToGame_Fields_FieldIdId",
                        column: x => x.FieldIdId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldToGame_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserIdId = table.Column<int>(nullable: true),
                    GameIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToGames_Games_GameIdId",
                        column: x => x.GameIdId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserToGames_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldToGame_FieldIdId",
                table: "FieldToGame",
                column: "FieldIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldToGame_GameIdId",
                table: "FieldToGame",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGames_GameIdId",
                table: "UserToGames",
                column: "GameIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGames_UserIdId",
                table: "UserToGames",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldToGame");

            migrationBuilder.DropTable(
                name: "UserToGames");
        }
    }
}
