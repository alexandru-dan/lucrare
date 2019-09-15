using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class relation_m_to_m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Fields_FieldId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_User1IdId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_User2IdId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_FieldId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_User1IdId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_User2IdId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "User1IdId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "User2IdId",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User1IdId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User2IdId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_FieldId",
                table: "Games",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_User1IdId",
                table: "Games",
                column: "User1IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_User2IdId",
                table: "Games",
                column: "User2IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Fields_FieldId",
                table: "Games",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_User1IdId",
                table: "Games",
                column: "User1IdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_User2IdId",
                table: "Games",
                column: "User2IdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
