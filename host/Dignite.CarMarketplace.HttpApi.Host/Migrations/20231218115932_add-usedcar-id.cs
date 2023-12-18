using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class addusedcarid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedCarId",
                table: "cmpUsedCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedCarId",
                table: "cmpUsedCars");
        }
    }
}
