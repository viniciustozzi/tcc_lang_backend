using Microsoft.EntityFrameworkCore.Migrations;

namespace tcc_lang_backend.Migrations
{
    public partial class migrations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Roles",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Roles",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
