using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class addsOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Decks_TextId",
                table: "Decks");

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "Texts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_TextId",
                table: "Decks",
                column: "TextId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Decks_TextId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Texts");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_TextId",
                table: "Decks",
                column: "TextId");
        }
    }
}
