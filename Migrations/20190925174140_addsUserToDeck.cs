using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class addsUserToDeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deck_Texts_TextId",
                table: "Deck");

            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Deck_DockerId",
                table: "Flashcards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deck",
                table: "Deck");

            migrationBuilder.RenameTable(
                name: "Deck",
                newName: "Decks");

            migrationBuilder.RenameIndex(
                name: "IX_Deck_TextId",
                table: "Decks",
                newName: "IX_Decks_TextId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Decks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Decks",
                table: "Decks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Texts_TextId",
                table: "Decks",
                column: "TextId",
                principalTable: "Texts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Users_UserId",
                table: "Decks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Decks_DockerId",
                table: "Flashcards",
                column: "DockerId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Texts_TextId",
                table: "Decks");

            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Users_UserId",
                table: "Decks");

            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Decks_DockerId",
                table: "Flashcards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Decks",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_UserId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Decks");

            migrationBuilder.RenameTable(
                name: "Decks",
                newName: "Deck");

            migrationBuilder.RenameIndex(
                name: "IX_Decks_TextId",
                table: "Deck",
                newName: "IX_Deck_TextId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deck",
                table: "Deck",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deck_Texts_TextId",
                table: "Deck",
                column: "TextId",
                principalTable: "Texts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Deck_DockerId",
                table: "Flashcards",
                column: "DockerId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
