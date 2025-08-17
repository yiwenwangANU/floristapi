using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloristApi.Migrations
{
    /// <inheritdoc />
    public partial class newflowertype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Flowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Flowers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Occasion",
                table: "Flowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlowerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerTypes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerFlowerType");

            migrationBuilder.DropTable(
                name: "FlowerTypes");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "Occasion",
                table: "Flowers");
        }
    }
}
