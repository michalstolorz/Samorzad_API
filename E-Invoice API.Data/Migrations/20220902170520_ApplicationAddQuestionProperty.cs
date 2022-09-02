using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Invoice_API.Data.Migrations
{
    public partial class ApplicationAddQuestionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Application",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Application");
        }
    }
}
