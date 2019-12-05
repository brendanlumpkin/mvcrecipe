using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCRecipe.Migrations
{
    public partial class recipeForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ApplicationUserId",
                table: "Recipe",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_ApplicationUserId",
                table: "Recipe",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipe",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
