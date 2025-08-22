using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloristApi.Migrations
{
    /// <inheritdoc />
    public partial class removeflowerid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerFlowerType");

            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "FlowerTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chocolate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chocolate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teddies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teddies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FlowerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlowerTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FlowerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_FlowerTypes_FlowerId",
                table: "FlowerTypes",
                column: "FlowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerTypes_Flowers_FlowerId",
                table: "FlowerTypes",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerTypes_Flowers_FlowerId",
                table: "FlowerTypes");

            migrationBuilder.DropTable(
                name: "Chocolate");

            migrationBuilder.DropTable(
                name: "Teddies");

            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_FlowerTypes_FlowerId",
                table: "FlowerTypes");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "FlowerTypes");

            migrationBuilder.CreateTable(
                name: "FlowerFlowerType",
                columns: table => new
                {
                    FlowerTypesId = table.Column<int>(type: "int", nullable: false),
                    FlowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerFlowerType", x => new { x.FlowerTypesId, x.FlowersId });
                    table.ForeignKey(
                        name: "FK_FlowerFlowerType_FlowerTypes_FlowerTypesId",
                        column: x => x.FlowerTypesId,
                        principalTable: "FlowerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerFlowerType_Flowers_FlowersId",
                        column: x => x.FlowersId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerFlowerType_FlowersId",
                table: "FlowerFlowerType",
                column: "FlowersId");
        }
    }
}
