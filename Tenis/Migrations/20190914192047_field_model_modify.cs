using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class field_model_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldNumber",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameId",
                table: "Fields",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldNumber",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Fields");
        }
    }
}
