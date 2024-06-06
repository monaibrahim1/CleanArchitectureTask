using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class create_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressCount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressCount_Governorate_Id",
                        column: x => x.Id,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citiy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citiy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citiy_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Citiy_CityId",
                        column: x => x.CityId,
                        principalTable: "Citiy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Governorate",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alexandria" },
                    { 2, "Assiut" },
                    { 3, "Aswan" },
                    { 4, "Beheira" },
                    { 5, "Bani Suef" },
                    { 6, "Cairo" },
                    { 7, "Daqahliya" },
                    { 8, "Damietta" },
                    { 9, "Fayyoum" },
                    { 10, "Gharbiya" },
                    { 11, "Giza" },
                    { 12, "Helwan" },
                    { 13, "Ismailia" },
                    { 14, "Kafr El Sheikh" },
                    { 15, "Luxor" },
                    { 16, "Marsa Matrouh" },
                    { 17, "Minya" },
                    { 18, "Monofiya" },
                    { 19, "New Valley" },
                    { 20, "North Sinai" },
                    { 21, "Port Said" },
                    { 22, "Qalioubiya" },
                    { 23, "Qena" },
                    { 24, "Red Sea" },
                    { 25, "Sharqiya" },
                    { 26, "Sohag" },
                    { 27, "South Sinai" },
                    { 28, "Suez" },
                    { 29, "Tanta" }
                });

            migrationBuilder.InsertData(
                table: "Citiy",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[,]
                {
                    { 1, 6, "Shubra" },
                    { 2, 6, "Obour" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citiy_GovernorateId",
                table: "Citiy",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GovernorateId",
                table: "User",
                column: "GovernorateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCount");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Citiy");

            migrationBuilder.DropTable(
                name: "Governorate");
        }
    }
}
