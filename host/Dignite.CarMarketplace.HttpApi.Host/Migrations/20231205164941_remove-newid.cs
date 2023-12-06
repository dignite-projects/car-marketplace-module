using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class removenewid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewId",
                table: "cmpTrims");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "cmpModels");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "cmpConfigurationItems");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "cmpBrands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: "cmpTrims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: "cmpModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: "cmpConfigurationItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: "cmpBrands",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
