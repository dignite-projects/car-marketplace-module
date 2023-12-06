using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class addUsedCarConsultation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cmpUsedCarConsultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsedCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpUsedCarConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cmpUsedCarConsultations_cmpUsedCars_UsedCarId",
                        column: x => x.UsedCarId,
                        principalTable: "cmpUsedCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCarConsultations_UsedCarId",
                table: "cmpUsedCarConsultations",
                column: "UsedCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cmpUsedCarConsultations");
        }
    }
}
