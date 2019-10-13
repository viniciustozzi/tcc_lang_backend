using Microsoft.EntityFrameworkCore.Migrations;

namespace TccLangBackend.Api.Migrations
{
    public partial class AddSourceLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Texts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Texts");
        }
    }
}
