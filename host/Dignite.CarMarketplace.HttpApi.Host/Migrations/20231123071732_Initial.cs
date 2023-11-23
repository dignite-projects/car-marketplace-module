using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dignite.CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cmpBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstLetter = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmpConfigurationItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpConfigurationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmpDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    AuthenticationStatus = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpDealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmpUsedCars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMileage = table.Column<float>(type: "real", nullable: false),
                    TransfersCount = table.Column<int>(type: "int", nullable: false),
                    CompulsoryInsuranceExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommercialInsuranceExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TransmissionType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PowerType = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ModelLevel = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpUsedCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmpUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmpModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cmpModels_cmpBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "cmpBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cmpDealerAdministrators",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpDealerAdministrators", x => new { x.DealerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_cmpDealerAdministrators_cmpDealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "cmpDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cmpTrims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmpTrims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cmpTrims_cmpModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "cmpModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cmpDealerAdministrators_DealerId",
                table: "cmpDealerAdministrators",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpDealerAdministrators_UserId",
                table: "cmpDealerAdministrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpModels_BrandId",
                table: "cmpModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpTrims_ModelId",
                table: "cmpTrims",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_BrandId",
                table: "cmpUsedCars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_Color",
                table: "cmpUsedCars",
                column: "Color");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_CreationTime",
                table: "cmpUsedCars",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_ModelId",
                table: "cmpUsedCars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_ModelLevel",
                table: "cmpUsedCars",
                column: "ModelLevel");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_PowerType",
                table: "cmpUsedCars",
                column: "PowerType");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_Price",
                table: "cmpUsedCars",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_RegistrationDate",
                table: "cmpUsedCars",
                column: "RegistrationDate");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_TransmissionType",
                table: "cmpUsedCars",
                column: "TransmissionType");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsedCars_TrimId",
                table: "cmpUsedCars",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_cmpUsers_TenantId_UserName",
                table: "cmpUsers",
                columns: new[] { "TenantId", "UserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cmpConfigurationItems");

            migrationBuilder.DropTable(
                name: "cmpDealerAdministrators");

            migrationBuilder.DropTable(
                name: "cmpTrims");

            migrationBuilder.DropTable(
                name: "cmpUsedCars");

            migrationBuilder.DropTable(
                name: "cmpUsers");

            migrationBuilder.DropTable(
                name: "cmpDealers");

            migrationBuilder.DropTable(
                name: "cmpModels");

            migrationBuilder.DropTable(
                name: "cmpBrands");
        }
    }
}
