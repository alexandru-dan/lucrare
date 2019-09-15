using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class modifyGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAndSurnameFirstPlayer",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NameAndSurnameSecondPlayer",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "NameAndSurnameFirstPlayerId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NameAndSurnameSecondPlayerId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_NameAndSurnameFirstPlayerId",
                table: "Games",
                column: "NameAndSurnameFirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_NameAndSurnameSecondPlayerId",
                table: "Games",
                column: "NameAndSurnameSecondPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_NameAndSurnameFirstPlayerId",
                table: "Games",
                column: "NameAndSurnameFirstPlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_NameAndSurnameSecondPlayerId",
                table: "Games",
                column: "NameAndSurnameSecondPlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_NameAndSurnameFirstPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_NameAndSurnameSecondPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_NameAndSurnameFirstPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_NameAndSurnameSecondPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NameAndSurnameFirstPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NameAndSurnameSecondPlayerId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "NameAndSurnameFirstPlayer",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAndSurnameSecondPlayer",
                table: "Games",
                nullable: true);
        }
    }
}
