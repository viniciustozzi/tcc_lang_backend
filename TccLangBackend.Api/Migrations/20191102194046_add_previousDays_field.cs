using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class add_previousDays_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousDays",
                table: "Flashcards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousDays",
                table: "Flashcards");
        }
    }
}
