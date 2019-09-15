using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class games_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldNameAndFieldNumber",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAndSurnameFirstPlayer",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAndSurnameSecondPlayer",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldNameAndFieldNumber",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NameAndSurnameFirstPlayer",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NameAndSurnameSecondPlayer",
                table: "Games");
        }
    }
}
