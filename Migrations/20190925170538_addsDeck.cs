using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tcc_lang_backend.Migrations
{
    public partial class addsDeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Flashcards_FlashcardId",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Texts_FlashcardId",
                table: "Texts");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "Texts");

            migrationBuilder.AddColumn<int>(
                name: "DockerId",
                table: "Flashcards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    TextId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deck_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_DockerId",
                table: "Flashcards",
                column: "DockerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deck_TextId",
                table: "Deck",
                column: "TextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_Deck_DockerId",
                table: "Flashcards",
                column: "DockerId",
                principalTable: "Deck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_Deck_DockerId",
                table: "Flashcards");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropIndex(
                name: "IX_Flashcards_DockerId",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "DockerId",
                table: "Flashcards");

            migrationBuilder.AddColumn<int>(
                name: "FlashcardId",
                table: "Texts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_FlashcardId",
                table: "Texts",
                column: "FlashcardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Flashcards_FlashcardId",
                table: "Texts",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
