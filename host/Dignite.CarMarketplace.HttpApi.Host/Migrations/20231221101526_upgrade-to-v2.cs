using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class upgradetov2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("cmpUsedCarConsultations","dbo", "cmpBuyUsedCars", "dbo");
            migrationBuilder.RenameTable("cmpSaleCars", "dbo", "cmpSaleUsedCars", "dbo");
            migrationBuilder.RenameTable("cmpConfigurationItems", "dbo", "cmpTrimConfigItems", "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("cmpBuyUsedCars", "dbo", "cmpUsedCarConsultations", "dbo");
            migrationBuilder.RenameTable("cmpSaleUsedCars", "dbo", "cmpSaleCars", "dbo");
            migrationBuilder.RenameTable("cmpTrimConfigItems", "dbo", "cmpConfigurationItems", "dbo");
        }
    }
}
