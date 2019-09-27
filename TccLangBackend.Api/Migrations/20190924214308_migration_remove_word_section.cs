using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TccLangBackend.Api.Migrations
{
    public partial class migration_remove_word_section : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordSections");

            migrationBuilder.AddColumn<string>(
                name: "Words",
                table: "Texts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Words",
                table: "Texts");

            migrationBuilder.CreateTable(
                name: "WordSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FlashcardId = table.Column<int>(nullable: true),
                    IsPressed = table.Column<bool>(nullable: false),
                    TextId = table.Column<int>(nullable: true),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordSections_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordSections_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordSections_FlashcardId",
                table: "WordSections",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_WordSections_TextId",
                table: "WordSections",
                column: "TextId");
        }
    }
}
