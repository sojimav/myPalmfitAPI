using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Data.Migrations
{
    /// <inheritdoc />
    public partial class V14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_FoodId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_Users_Meal_AppUserId",
                table: "BaseEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_FoodId",
                table: "BaseEntity",
                column: "FoodId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_Users_Meal_AppUserId",
                table: "BaseEntity",
                column: "Meal_AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_FoodId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_Users_Meal_AppUserId",
                table: "BaseEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_FoodId",
                table: "BaseEntity",
                column: "FoodId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_Users_Meal_AppUserId",
                table: "BaseEntity",
                column: "Meal_AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
