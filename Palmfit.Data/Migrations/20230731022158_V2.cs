using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Data.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_MealPlans_MealPlanId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MealPlanId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "FoodId",
                table: "MealPlans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_FoodId",
                table: "MealPlans",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Foods_FoodId",
                table: "MealPlans",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Foods_FoodId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_FoodId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "MealPlans");

            migrationBuilder.AddColumn<string>(
                name: "MealPlanId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealPlanId",
                table: "Foods",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_MealPlans_MealPlanId",
                table: "Foods",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id");
        }
    }
}
