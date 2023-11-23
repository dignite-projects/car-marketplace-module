using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddCmskitModule1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CmsFavourites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsFavourites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsVisits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsFavourites_TenantId_EntityType_EntityId_CreatorId",
                table: "CmsFavourites",
                columns: new[] { "TenantId", "EntityType", "EntityId", "CreatorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CmsVisits_TenantId_EntityType_EntityId_ClientIpAddress",
                table: "CmsVisits",
                columns: new[] { "TenantId", "EntityType", "EntityId", "ClientIpAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_CmsVisits_TenantId_EntityType_EntityId_CreatorId",
                table: "CmsVisits",
                columns: new[] { "TenantId", "EntityType", "EntityId", "CreatorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmsFavourites");

            migrationBuilder.DropTable(
                name: "CmsVisits");
        }
    }
}
