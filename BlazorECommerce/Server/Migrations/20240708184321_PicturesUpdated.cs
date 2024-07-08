using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class PicturesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/d/d9/Foundation_-_Isaac_Asimov_%28Gnome_1951%29.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/7/73/Hyperion_cover.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/e/e4/Ender%27s_game_cover_ISBN_0312932081.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/6109I16IWpL._SL1057_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/8/88/TheLeftHandOfDarkness1stEd.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/4/40/Stranger_in_a_Strange_Land_Cover.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/2/25/Foundation_gnome.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/a/a1/Hyperion_cover.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/9/95/Ender%27s_Game_cover_ISBN_0312932081.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/c/c3/The_Martian_2014.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/2/29/TheLeftHandOfDarkness1stEd.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/8/84/StrangerInaStrangeLand_Cover.jpg");
        }
    }
}
