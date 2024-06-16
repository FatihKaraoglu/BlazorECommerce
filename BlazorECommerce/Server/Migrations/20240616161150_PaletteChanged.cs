using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class PaletteChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonoChromeColor1",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "MonoChromeColor2",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "MonoChromeColor3",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "MonoChromeColor4",
                table: "Palettes");

            migrationBuilder.RenameColumn(
                name: "MonoChromeColor5",
                table: "Palettes",
                newName: "PrimaryColor");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColorDarken",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColorLighten",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColorDarken",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColorLighten",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TertiaryDarken",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TertiaryLighten",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryColorDarken",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "PrimaryColorLighten",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "SecondaryColorDarken",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "SecondaryColorLighten",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "TertiaryDarken",
                table: "Palettes");

            migrationBuilder.DropColumn(
                name: "TertiaryLighten",
                table: "Palettes");

            migrationBuilder.RenameColumn(
                name: "PrimaryColor",
                table: "Palettes",
                newName: "MonoChromeColor5");

            migrationBuilder.AddColumn<string>(
                name: "MonoChromeColor1",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonoChromeColor2",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonoChromeColor3",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonoChromeColor4",
                table: "Palettes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
