using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Data.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_AppUserId",
                table: "Meals",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_AppUserId",
                table: "Meals",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_AppUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_AppUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Meals");
        }
    }
}
