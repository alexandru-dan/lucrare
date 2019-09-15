using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class deleted_table_games_to_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldToGame");

            migrationBuilder.DropColumn(
                name: "FieldNameAndFieldNumber",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "FieldNameAndFieldNumberId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_FieldNameAndFieldNumberId",
                table: "Games",
                column: "FieldNameAndFieldNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Fields_FieldNameAndFieldNumberId",
                table: "Games",
                column: "FieldNameAndFieldNumberId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Fields_FieldNameAndFieldNumberId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_FieldNameAndFieldNumberId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FieldNameAndFieldNumberId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "FieldNameAndFieldNumber",
                table: "Games",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FieldToGame_FieldIdId",
                table: "FieldToGame",
                column: "FieldIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldToGame_GameIdId",
                table: "FieldToGame",
                column: "GameIdId");
        }
    }
}
