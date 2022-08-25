using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Invoice_API.Data.Migrations
{
    public partial class ModelsConfigurationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationComment_Application_ApplicationId",
                table: "ApplicationComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserVote_Application_ApplicationId",
                table: "ApplicationUserVote");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationComment_Application_ApplicationId",
                table: "ApplicationComment",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserVote_Application_ApplicationId",
                table: "ApplicationUserVote",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationComment_Application_ApplicationId",
                table: "ApplicationComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserVote_Application_ApplicationId",
                table: "ApplicationUserVote");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationComment_Application_ApplicationId",
                table: "ApplicationComment",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserVote_Application_ApplicationId",
                table: "ApplicationUserVote",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
