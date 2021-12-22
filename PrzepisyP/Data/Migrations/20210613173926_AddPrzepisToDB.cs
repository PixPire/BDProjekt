using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzepisyP.Data.Migrations
{
    public partial class AddPrzepisToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przepis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Składniki = table.Column<string>(nullable: false),
                    Wykonanie = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przepis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Przepis_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Przepis_UserID",
                table: "Przepis",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przepis");
        }
    }
}
