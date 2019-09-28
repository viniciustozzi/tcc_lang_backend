using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class fixFieldTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Decks_DockerId",
                table: "Flashcards");

            migrationBuilder.RenameColumn(
                name: "DockerId",
                table: "Flashcards",
                newName: "DeckId");

            migrationBuilder.RenameIndex(
                name: "IX_Flashcards_DockerId",
                table: "Flashcards",
                newName: "IX_Flashcards_DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Decks_DeckId",
                table: "Flashcards",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Decks_DeckId",
                table: "Flashcards");

            migrationBuilder.RenameColumn(
                name: "DeckId",
                table: "Flashcards",
                newName: "DockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Flashcards_DeckId",
                table: "Flashcards",
                newName: "IX_Flashcards_DockerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Decks_DockerId",
                table: "Flashcards",
                column: "DockerId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
