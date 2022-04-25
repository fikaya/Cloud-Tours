using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudTours.Persistence.Migrations
{
    public partial class Buses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusManuFacturers",
                columns: table => new
                {
                    BusManuFacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusManuFacturers", x => x.BusManuFacturerId);
                });

            migrationBuilder.CreateTable(
                name: "BusModels",
                columns: table => new
                {
                    BusModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusModelName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    BusManuFacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusModels", x => x.BusModelId);
                    table.ForeignKey(
                        name: "FK_BusModels_BusManuFacturers_BusManuFacturerId",
                        column: x => x.BusManuFacturerId,
                        principalTable: "BusManuFacturers",
                        principalColumn: "BusManuFacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationPlate = table.Column<string>(type: "varchar(150)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeatMapping = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveled = table.Column<int>(type: "int", nullable: false),
                    BusModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                    table.ForeignKey(
                        name: "FK_Buses_BusModels_BusModelId",
                        column: x => x.BusModelId,
                        principalTable: "BusModels",
                        principalColumn: "BusModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusManuFacturers",
                columns: new[] { "BusManuFacturerId", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "Man" },
                    { 3, "Neoplan" },
                    { 4, "Isuzu" }
                });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "BusModelId", "BusManuFacturerId", "BusModelName", "HasToilet", "SeatCapacity", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Mercedess Travego2", true, 44, 2 },
                    { 3, 1, "Mercedess Travego1", false, 44, 2 },
                    { 2, 2, "Man-Fortuna", true, 0, 0 },
                    { 5, 2, "Man-Lions", true, 26, 1 },
                    { 4, 3, "Starliner", true, 44, 2 },
                    { 6, 4, "Citibus", true, 44, 2 },
                    { 7, 4, "Citimark", false, 52, 2 },
                    { 8, 4, "Novociti", true, 48, 2 }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[,]
                {
                    { 6, 1, 7800, "34-FBS-123", 2, 2020 },
                    { 2, 3, 10000, "17-ASS-562", 1, 2020 },
                    { 3, 3, 62000, "34-OBS-123", 3, 2013 },
                    { 1, 2, 50000, "34-OBS-123", 1, 2015 },
                    { 7, 2, 8000, "34-OBS-123", 1, 2013 },
                    { 5, 5, 31000, "34-OBS-123", 2, 2018 },
                    { 4, 4, 2000, "34-OBS-123", 3, 2016 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusModelId",
                table: "Buses",
                column: "BusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BusModels_BusManuFacturerId",
                table: "BusModels",
                column: "BusManuFacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "BusModels");

            migrationBuilder.DropTable(
                name: "BusManuFacturers");
        }
    }
}
