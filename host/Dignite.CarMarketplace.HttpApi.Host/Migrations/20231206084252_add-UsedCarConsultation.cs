using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class addUsedCarConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                table: "cmpUsedCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "cmpUsedCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                table: "cmpUsedCars");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "cmpUsedCars");
        }
    }
}
