using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class User_to_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserIdId",
                table: "UserDetails",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_UserIdId",
                table: "UserDetails",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_UserIdId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserIdId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "UserDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserDetails",
                nullable: false,
                defaultValue: 0);
        }
    }
}
