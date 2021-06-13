using Microsoft.EntityFrameworkCore.Migrations;

namespace Klir.TechChallenge.Web.Api.Migrations
{
    public partial class Adding_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromotionsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PromotionsId",
                table: "Products",
                column: "PromotionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Promotions_PromotionsId",
                table: "Products",
                column: "PromotionsId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Promotions_PromotionsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PromotionsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PromotionsId",
                table: "Products");
        }
    }
}
