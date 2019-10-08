using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class change_flashcard_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Flashcards",
                newName: "TranslatedWord");

            migrationBuilder.AddColumn<string>(
                name: "OriginalWord",
                table: "Flashcards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalWord",
                table: "Flashcards");

            migrationBuilder.RenameColumn(
                name: "TranslatedWord",
                table: "Flashcards",
                newName: "Title");
        }
    }
}
