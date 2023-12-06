using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddUsedCarDealerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_DealerId",
                table: "cmpUsedCars",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cmpUsedCars_cmpDealers_DealerId",
                table: "cmpUsedCars",
                column: "DealerId",
                principalTable: "cmpDealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cmpUsedCars_cmpDealers_DealerId",
                table: "cmpUsedCars");

            migrationBuilder.DropIndex(
                name: "IX_cmpUsedCars_DealerId",
                table: "cmpUsedCars");
        }
    }
}
