using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenis.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Fields",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Name = table.Column<string>(nullable: true),
        //            Address = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Fields", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Games",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            User1Id = table.Column<int>(nullable: false),
        //            User2Id = table.Column<int>(nullable: false),
        //            FieldId = table.Column<int>(nullable: false),
        //            Score = table.Column<string>(nullable: true),
        //            Status = table.Column<string>(nullable: true),
        //            DateTime = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Games", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserDetails",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            UserId = table.Column<int>(nullable: false),
        //            Level = table.Column<int>(nullable: false),
        //            Hand = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserDetails", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            FirstName = table.Column<string>(nullable: true),
        //            LastName = table.Column<string>(nullable: true),
        //            Username = table.Column<string>(nullable: true),
        //            Email = table.Column<string>(nullable: true),
        //            Password = table.Column<string>(nullable: true),
        //            UserRole = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserToDetails",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            UserId = table.Column<int>(nullable: false),
        //            UserDetails = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserToDetails", x => x.Id);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Username",
        //        table: "Users",
        //        column: "Username",
        //        unique: true,
        //        filter: "[Username] IS NOT NULL");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Fields");

        //    migrationBuilder.DropTable(
        //        name: "Games");

        //    migrationBuilder.DropTable(
        //        name: "UserDetails");

        //    migrationBuilder.DropTable(
        //        name: "Users");

        //    migrationBuilder.DropTable(
        //        name: "UserToDetails");
        }
    }
}
