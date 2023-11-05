using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/5/51/1984_first_edition_cover.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg");
        }
    }
}
