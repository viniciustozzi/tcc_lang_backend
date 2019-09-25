using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TccLangBackend.DB.Migrations
{
    public partial class migration_create_flashcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashcardId",
                table: "WordSections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlashcardId",
                table: "Texts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordSections_FlashcardId",
                table: "WordSections",
                column: "FlashcardId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WordSections_Flashcards_FlashcardId",
                table: "WordSections",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Flashcards_FlashcardId",
                table: "Texts");

            migrationBuilder.DropForeignKey(
                name: "FK_WordSections_Flashcards_FlashcardId",
                table: "WordSections");

            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropIndex(
                name: "IX_WordSections_FlashcardId",
                table: "WordSections");

            migrationBuilder.DropIndex(
                name: "IX_Texts_FlashcardId",
                table: "Texts");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "WordSections");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "Texts");
        }
    }
}
