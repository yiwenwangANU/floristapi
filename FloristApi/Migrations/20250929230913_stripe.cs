using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloristApi.Migrations
{
    /// <inheritdoc />
    public partial class stripe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeProductId",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "Teddies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeProductId",
                table: "Teddies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeProductId",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeProductId",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "Chocolate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeProductId",
                table: "Chocolate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "StripeProductId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "Teddies");

            migrationBuilder.DropColumn(
                name: "StripeProductId",
                table: "Teddies");

            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "StripeProductId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "StripeProductId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "Chocolate");

            migrationBuilder.DropColumn(
                name: "StripeProductId",
                table: "Chocolate");
        }
    }
}
