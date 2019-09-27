using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class addsUserToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Texts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_UserId",
                table: "Texts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Texts_UserId",
                table: "Texts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Texts");
        }
    }
}
