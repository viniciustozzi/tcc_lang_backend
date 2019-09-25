using Microsoft.EntityFrameworkCore.Migrations;

namespace tcc_lang_backend.Migrations
{
    public partial class migration_flashcard_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Flashcards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Flashcards");
        }
    }
}
