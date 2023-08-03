using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Api.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId1",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId2",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "DailyMealPlanId2",
                table: "Foods",
                newName: "LunchId");

            migrationBuilder.RenameColumn(
                name: "DailyMealPlanId1",
                table: "Foods",
                newName: "DinnerId");

            migrationBuilder.RenameColumn(
                name: "DailyMealPlanId",
                table: "Foods",
                newName: "BreakfastId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DailyMealPlanId2",
                table: "Foods",
                newName: "IX_Foods_LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DailyMealPlanId1",
                table: "Foods",
                newName: "IX_Foods_DinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DailyMealPlanId",
                table: "Foods",
                newName: "IX_Foods_BreakfastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_BreakfastId",
                table: "Foods",
                column: "BreakfastId",
                principalTable: "DailyMealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_DinnerId",
                table: "Foods",
                column: "DinnerId",
                principalTable: "DailyMealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_LunchId",
                table: "Foods",
                column: "LunchId",
                principalTable: "DailyMealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_BreakfastId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_DinnerId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMealPlans_LunchId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "LunchId",
                table: "Foods",
                newName: "DailyMealPlanId2");

            migrationBuilder.RenameColumn(
                name: "DinnerId",
                table: "Foods",
                newName: "DailyMealPlanId1");

            migrationBuilder.RenameColumn(
                name: "BreakfastId",
                table: "Foods",
                newName: "DailyMealPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_LunchId",
                table: "Foods",
                newName: "IX_Foods_DailyMealPlanId2");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DinnerId",
                table: "Foods",
                newName: "IX_Foods_DailyMealPlanId1");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_BreakfastId",
                table: "Foods",
                newName: "IX_Foods_DailyMealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId",
                table: "Foods",
                column: "DailyMealPlanId",
                principalTable: "DailyMealPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId1",
                table: "Foods",
                column: "DailyMealPlanId1",
                principalTable: "DailyMealPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMealPlans_DailyMealPlanId2",
                table: "Foods",
                column: "DailyMealPlanId2",
                principalTable: "DailyMealPlans",
                principalColumn: "Id");
        }
    }
}
