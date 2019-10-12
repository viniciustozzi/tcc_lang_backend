using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class TextRemoveUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Decks_TextId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Texts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Texts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Decks_TextId",
                table: "Decks",
                column: "TextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Decks_TextId",
                table: "Decks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Texts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "Texts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_TextId",
                table: "Decks",
                column: "TextId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Users_UserId",
                table: "Texts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
