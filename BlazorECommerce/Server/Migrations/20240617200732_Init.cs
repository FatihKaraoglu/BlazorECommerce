using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.ProductId, x.ProductTypeId });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Quanity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Featured", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, false, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><path d=\"M19.8,18.4L14,10.67V6.5l1.35-1.69C15.61,4.48,15.38,4,14.96,4H9.04C8.62,4,8.39,4.48,8.65,4.81L10,6.5v4.17L4.2,18.4 C3.71,19.06,4.18,20,5,20h14C19.82,20,20.29,19.06,19.8,18.4z\"/></g>", "Science-Fiction", "science-fiction" },
                    { 2, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M7.5 5.6L10 7 8.6 4.5 10 2 7.5 3.4 5 2l1.4 2.5L5 7zm12 9.8L17 14l1.4 2.5L17 19l2.5-1.4L22 19l-1.4-2.5L22 14zM22 2l-2.5 1.4L17 2l1.4 2.5L17 7l2.5-1.4L22 7l-1.4-2.5zm-7.63 5.29c-.39-.39-1.02-.39-1.41 0L1.29 18.96c-.39.39-.39 1.02 0 1.41l2.34 2.34c.39.39 1.02.39 1.41 0L16.7 11.05c.39-.39.39-1.02 0-1.41l-2.33-2.35zm-1.03 5.49l-2.12-2.12 2.44-2.44 2.12 2.12-2.44 2.44z\"/>", "Fantasy", "fantasy" },
                    { 3, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z\"/>", "Romance", "romance" },
                    { 4, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M7 2v11h3v9l7-12h-4l4-8z\"/>", "Thriller", "thriller" },
                    { 5, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z\"/>", "Biography", "biography" },
                    { 6, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><circle cx=\"14.5\" cy=\"10.5\" r=\"1.25\"/><circle cx=\"9.5\" cy=\"10.5\" r=\"1.25\"/><path d=\"M22.94 12.66c.04-.21.06-.43.06-.66s-.02-.45-.06-.66c-.25-1.51-1.36-2.74-2.81-3.17-.53-1.12-1.28-2.1-2.19-2.91C16.36 3.85 14.28 3 12 3s-4.36.85-5.94 2.26c-.92.81-1.67 1.8-2.19 2.91-1.45.43-2.56 1.65-2.81 3.17-.04.21-.06.43-.06.66s.02.45.06.66c.25 1.51 1.36 2.74 2.81 3.17.52 1.11 1.27 2.09 2.17 2.89C7.62 20.14 9.71 21 12 21s4.38-.86 5.97-2.28c.9-.8 1.65-1.79 2.17-2.89 1.44-.43 2.55-1.65 2.8-3.17zM19 14c-.1 0-.19-.02-.29-.03-.2.67-.49 1.29-.86 1.86C16.6 17.74 14.45 19 12 19s-4.6-1.26-5.85-3.17c-.37-.57-.66-1.19-.86-1.86-.1.01-.19.03-.29.03-1.1 0-2-.9-2-2s.9-2 2-2c.1 0 .19.02.29.03.2-.67.49-1.29.86-1.86C7.4 6.26 9.55 5 12 5s4.6 1.26 5.85 3.17c.37.57.66 1.19.86 1.86.1-.01.19-.03.29-.03 1.1 0 2 .9 2 2s-.9 2-2 2zM7.5 14c.76 1.77 2.49 3 4.5 3s3.74-1.23 4.5-3h-9z\"/>", "Children", "children" },
                    { 7, false, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><g/><g><path d=\"M21,5c-1.11-0.35-2.33-0.5-3.5-0.5c-1.95,0-4.05,0.4-5.5,1.5c-1.45-1.1-3.55-1.5-5.5-1.5S2.45,4.9,1,6v14.65 c0,0.25,0.25,0.5,0.5,0.5c0.1,0,0.15-0.05,0.25-0.05C3.1,20.45,5.05,20,6.5,20c1.95,0,4.05,0.4,5.5,1.5c1.35-0.85,3.8-1.5,5.5-1.5 c1.65,0,3.35,0.3,4.75,1.05c0.1,0.05,0.15,0.05,0.25,0.05c0.25,0,0.5-0.25,0.5-0.5V6C22.4,5.55,21.75,5.25,21,5z M21,18.5 c-1.1-0.35-2.3-0.5-3.5-0.5c-1.7,0-4.15,0.65-5.5,1.5V8c1.35-0.85,3.8-1.5,5.5-1.5c1.2,0,2.4,0.15,3.5,0.5V18.5z\"/><g><path d=\"M17.5,10.5c0.88,0,1.73,0.09,2.5,0.26V9.24C19.21,9.09,18.36,9,17.5,9c-1.7,0-3.24,0.29-4.5,0.83v1.66 C14.13,10.85,15.7,10.5,17.5,10.5z\"/><path d=\"M13,12.49v1.66c1.13-0.64,2.7-0.99,4.5-0.99c0.88,0,1.73,0.09,2.5,0.26V11.9c-0.79-0.15-1.64-0.24-2.5-0.24 C15.8,11.66,14.26,11.96,13,12.49z\"/><path d=\"M17.5,14.33c-1.7,0-3.24,0.29-4.5,0.83v1.66c1.13-0.64,2.7-0.99,4.5-0.99c0.88,0,1.73,0.09,2.5,0.26v-1.52 C19.21,14.41,18.36,14.33,17.5,14.33z\"/></g></g></g>", "Classic", "classic" },
                    { 8, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M8.1 13.34l2.83-2.83L3.91 3.5c-1.56 1.56-1.56 4.09 0 5.66l4.19 4.18zm6.78-1.81c1.53.71 3.68.21 5.27-1.38 1.91-1.91 2.28-4.65.81-6.12-1.46-1.46-4.2-1.1-6.12.81-1.59 1.59-2.09 3.74-1.38 5.27L3.7 19.87l1.41 1.41L12 14.41l6.88 6.88 1.41-1.41L13.41 13l1.47-1.47z\"/>", "Cooking", "cooking" },
                    { 9, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M20.57 14.86L22 13.43 20.57 12 17 15.57 8.43 7 12 3.43 10.57 2 9.14 3.43 7.71 2 5.57 4.14 4.14 2.71 2.71 4.14l1.43 1.43L2 7.71l1.43 1.43L2 10.57 3.43 12 7 8.43 15.57 17 12 20.57 13.43 22l1.43-1.43L16.29 22l2.14-2.14 1.43 1.43 1.43-1.43-1.43-1.43L22 16.29z\"/>", "Health & Fitness", "health-fitness" },
                    { 10, false, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><path d=\"M12,2C6.49,2,2,6.49,2,12s4.49,10,10,10c1.38,0,2.5-1.12,2.5-2.5c0-0.61-0.23-1.2-0.64-1.67c-0.08-0.1-0.13-0.21-0.13-0.33 c0-0.28,0.22-0.5,0.5-0.5H16c3.31,0,6-2.69,6-6C22,6.04,17.51,2,12,2z M17.5,13c-0.83,0-1.5-0.67-1.5-1.5c0-0.83,0.67-1.5,1.5-1.5 s1.5,0.67,1.5,1.5C19,12.33,18.33,13,17.5,13z M14.5,9C13.67,9,13,8.33,13,7.5C13,6.67,13.67,6,14.5,6S16,6.67,16,7.5 C16,8.33,15.33,9,14.5,9z M5,11.5C5,10.67,5.67,10,6.5,10S8,10.67,8,11.5C8,12.33,7.33,13,6.5,13S5,12.33,5,11.5z M11,7.5 C11,8.33,10.33,9,9.5,9S8,8.33,8,7.5C8,6.67,8.67,6,9.5,6S11,6.67,11,7.5z\"/></g>", "Art", "art" },
                    { 11, false, "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><path d=\"M19.8,18.4L14,10.67V6.5l1.35-1.69C15.61,4.48,15.38,4,14.96,4H9.04C8.62,4,8.39,4.48,8.65,4.81L10,6.5v4.17L4.2,18.4 C3.71,19.06,4.18,20,5,20h14C19.82,20,20.29,19.06,19.8,18.4z\"/></g>", "Science", "science" },
                    { 12, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M13.49 5.48c1.1 0 2-.9 2-2s-.9-2-2-2-2 .9-2 2 .9 2 2 2zm-3.6 13.9l1-4.4 2.1 2v6h2v-7.5l-2.1-2 .6-3c1.3 1.5 3.3 2.5 5.5 2.5v-2c-1.9 0-3.5-1-4.3-2.4l-1-1.6c-.4-.6-1-1-1.7-1-.3 0-.5.1-.8.1l-5.2 2.2v4.7h2v-3.4l1.8-.7-1.6 8.1-4.9-1-.4 2 7 1.4z\"/>", "Sport", "sport" },
                    { 13, false, "<path d=\"M0 0h24v24H0V0z\" fill=\"none\"/><circle cx=\"15.5\" cy=\"9.5\" r=\"1.5\"/><circle cx=\"8.5\" cy=\"9.5\" r=\"1.5\"/><path d=\"M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm0-6c-2.33 0-4.32 1.45-5.12 3.5h1.67c.69-1.19 1.97-2 3.45-2s2.75.81 3.45 2h1.67c-.8-2.05-2.79-3.5-5.12-3.5z\"/>", "Horror", "horror" },
                    { 14, false, "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm-2 15-5-5 1.41-1.41L10 14.17l7.59-7.59L19 8l-9 9z\"/>", "Self-Help", "self-help" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name", "PrimaryColor" },
                values: new object[] { 1, "BookWorld", "Leaf" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AuthorId", "Description", "Featured", "ImageUrl", "Title", "Views" },
                values: new object[,]
                {
                    { 1, null, "Neuromancer is a science fiction novel by American-Canadian writer William Gibson, published in 1984.", false, "https://upload.wikimedia.org/wikipedia/en/4/4b/Neuromancer_%28Book%29.jpg", "Neuromancer", 0 },
                    { 2, null, "Snow Crash is a science fiction novel by American writer Neal Stephenson, published in 1992.", false, "https://upload.wikimedia.org/wikipedia/en/d/d5/Snowcrash.jpg", "Snow Crash", 0 },
                    { 3, null, "Foundation is a science fiction novel by American writer Isaac Asimov, first published in 1951.", false, "https://upload.wikimedia.org/wikipedia/en/2/25/Foundation_gnome.jpg", "Foundation", 0 },
                    { 4, null, "Brave New World is a dystopian social science fiction novel by English author Aldous Huxley, published in 1932.", false, "https://upload.wikimedia.org/wikipedia/en/6/62/BraveNewWorld_FirstEdition.jpg", "Brave New World", 0 },
                    { 5, null, "Hyperion is a science fiction novel by American author Dan Simmons, published in 1989.", false, "https://upload.wikimedia.org/wikipedia/en/a/a1/Hyperion_cover.jpg", "Hyperion", 0 },
                    { 6, null, "Ender's Game is a 1985 military science fiction novel by American author Orson Scott Card.", false, "https://upload.wikimedia.org/wikipedia/en/9/95/Ender%27s_Game_cover_ISBN_0312932081.jpg", "Ender's Game", 0 },
                    { 7, null, "The Martian is a 2011 science fiction novel written by Andy Weir.", false, "https://upload.wikimedia.org/wikipedia/en/c/c3/The_Martian_2014.jpg", "The Martian", 0 },
                    { 8, null, "The Left Hand of Darkness is a science fiction novel by U.S. writer Ursula K. Le Guin, published in 1969.", false, "https://upload.wikimedia.org/wikipedia/en/2/29/TheLeftHandOfDarkness1stEd.jpg", "The Left Hand of Darkness", 0 },
                    { 9, null, "Stranger in a Strange Land is a 1961 science fiction novel by American author Robert A. Heinlein.", false, "https://upload.wikimedia.org/wikipedia/en/8/84/StrangerInaStrangeLand_Cover.jpg", "Stranger in a Strange Land", 0 },
                    { 10, null, "Do Androids Dream of Electric Sheep? is a science fiction novel by American writer Philip K. Dick, published in 1968.", false, "https://upload.wikimedia.org/wikipedia/en/e/ee/DoAndroidsDream.png", "Do Androids Dream of Electric Sheep?", 0 },
                    { 11, null, "The Road is a 2006 novel by American writer Cormac McCarthy. It is a post-apocalyptic story of a father and his young son.", false, "https://upload.wikimedia.org/wikipedia/en/6/6b/The-road.jpg", "The Road", 0 },
                    { 12, null, "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.", false, "https://upload.wikimedia.org/wikipedia/en/d/dc/The_Hunger_Games.jpg", "The Hunger Games", 0 },
                    { 13, null, "Ready Player Two is a 2020 science fiction novel by American author Ernest Cline.", false, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_Two.jpg", "Ready Player Two", 0 },
                    { 14, null, "Fahrenheit 451 is a 1953 dystopian novel by American writer Ray Bradbury.", false, "https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg", "Fahrenheit 451", 0 },
                    { 15, null, "The Handmaid's Tale is a dystopian novel by Canadian author Margaret Atwood, published in 1985.", false, "https://upload.wikimedia.org/wikipedia/en/b/ba/TheHandmaidsTale.jpg", "The Handmaid's Tale", 0 },
                    { 16, null, "Altered Carbon is a 2002 science fiction novel by the English author Richard K. Morgan.", false, "https://upload.wikimedia.org/wikipedia/en/b/b5/Altered_Carbon_%28cover%29.jpg", "Altered Carbon", 0 },
                    { 17, null, "Leviathan Wakes is a science fiction novel by James S. A. Corey, the first book in The Expanse series.", false, "https://upload.wikimedia.org/wikipedia/en/0/03/Leviathan_Wakes.jpg", "The Expanse: Leviathan Wakes", 0 },
                    { 18, null, "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", true, "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", "The Hobbit", 0 },
                    { 19, null, "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", false, "https://upload.wikimedia.org/wikipedia/en/9/93/AGameOfThrones.jpg", "A Game of Thrones", 0 },
                    { 20, null, "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J.K. Rowling.", false, "https://upload.wikimedia.org/wikipedia/en/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg", "Harry Potter and the Philosopher's Stone", 0 },
                    { 22, null, "The Way of Kings is an epic fantasy novel written by American author Brandon Sanderson.", false, "https://upload.wikimedia.org/wikipedia/en/8/81/TheWayOfKings.png", "The Way of Kings", 0 },
                    { 23, null, "Mistborn: The Final Empire is a fantasy novel written by American author Brandon Sanderson.", false, "https://upload.wikimedia.org/wikipedia/en/6/6d/Mistborn-cover.jpg", "Mistborn: The Final Empire", 0 },
                    { 24, null, "The Lies of Locke Lamora is a fantasy novel by American writer Scott Lynch.", false, "https://upload.wikimedia.org/wikipedia/en/4/4c/The_Lies_of_Locke_Lamora.jpg", "The Lies of Locke Lamora", 0 },
                    { 25, null, "Uprooted is a fantasy novel written by Naomi Novik.", false, "https://upload.wikimedia.org/wikipedia/en/a/a7/Uprooted_book_cover.jpg", "Uprooted", 0 },
                    { 26, null, "Circe is a 2018 novel by American writer Madeline Miller.", false, "https://upload.wikimedia.org/wikipedia/en/4/4b/Circe-novel.jpg", "Circe", 0 },
                    { 27, null, "The Night Circus is a fantasy novel by Erin Morgenstern.", false, "https://upload.wikimedia.org/wikipedia/en/a/a5/TheNightCircus.jpg", "The Night Circus", 0 },
                    { 28, null, "Good Omens: The Nice and Accurate Prophecies of Agnes Nutter, Witch is a 1990 novel written by Neil Gaiman and Terry Pratchett.", false, "https://upload.wikimedia.org/wikipedia/en/1/1d/GoodOmensCover.jpg", "Good Omens", 0 },
                    { 29, null, "American Gods is a fantasy novel by British author Neil Gaiman.", false, "https://upload.wikimedia.org/wikipedia/en/a/a4/American_Gods.jpg", "American Gods", 0 },
                    { 30, null, "The Ocean at the End of the Lane is a 2013 novel by British author Neil Gaiman.", false, "https://upload.wikimedia.org/wikipedia/en/4/4e/Ocean_at_the_End_of_the_Lane_US_cover.jpg", "The Ocean at the End of the Lane", 0 },
                    { 31, null, "The Color of Magic is a 1983 fantasy novel by British writer Terry Pratchett, the first book in his Discworld series.", false, "https://upload.wikimedia.org/wikipedia/en/3/3d/The_Colour_of_Magic_%28cover_art%29.jpg", "The Color of Magic", 0 },
                    { 32, null, "Mort is a fantasy novel by British writer Terry Pratchett, the fourth book in his Discworld series.", false, "https://upload.wikimedia.org/wikipedia/en/8/81/Mort_%28Terry_Pratchett_novel_-_cover_art%29.jpg", "Mort", 0 },
                    { 33, null, "Small Gods is the thirteenth of Terry Pratchett's Discworld novels, published in 1992.", false, "https://upload.wikimedia.org/wikipedia/en/8/8c/Smallgods.jpg", "Small Gods", 0 },
                    { 34, null, "Guards! Guards! is a fantasy novel by British writer Terry Pratchett, the eighth book in his Discworld series.", false, "https://upload.wikimedia.org/wikipedia/en/2/20/Guards-Guards-cover.jpg", "Guards! Guards!", 0 },
                    { 35, null, "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", false, "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", "The Hobbit", 0 },
                    { 36, null, "The Fellowship of the Ring is the first of three volumes of the epic novel The Lord of the Rings by the English author J. R. R. Tolkien.", false, "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif", "The Fellowship of the Ring", 0 },
                    { 37, null, "The Two Towers is the second volume of J.R.R. Tolkien's high-fantasy novel The Lord of the Rings.", false, "https://upload.wikimedia.org/wikipedia/en/a/a1/The_Two_Towers_cover.gif", "The Two Towers", 0 },
                    { 38, null, "The Return of the King is the third and final volume of J.R.R. Tolkien's The Lord of the Rings.", false, "https://upload.wikimedia.org/wikipedia/en/1/11/The_Return_of_the_King_cover.gif", "The Return of the King", 0 },
                    { 39, null, "The Silmarillion is a collection of mythopoeic works by English writer J. R. R. Tolkien, edited and published posthumously by his son, Christopher Tolkien.", false, "https://upload.wikimedia.org/wikipedia/en/a/a4/The_Silmarillion_first_edition.jpg", "The Silmarillion", 0 },
                    { 40, null, "The Catcher in the Rye is a novel by J. D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951.", false, "https://upload.wikimedia.org/wikipedia/en/3/32/Rye_catcher.jpg", "The Catcher in the Rye", 0 },
                    { 41, null, "To Kill a Mockingbird is a novel by Harper Lee published in 1960.", false, "https://upload.wikimedia.org/wikipedia/en/7/79/To_Kill_a_Mockingbird.JPG", "To Kill a Mockingbird", 0 },
                    { 42, null, "Nineteen Eighty-Four, often referred to as 1984, is a dystopian social science fiction novel by the English writer George Orwell.", false, "https://upload.wikimedia.org/wikipedia/en/c/c3/1984first.jpg", "1984", 0 },
                    { 44, null, "Pride and Prejudice is a romantic novel of manners written by Jane Austen in 1813.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Title_page_of_Pride_and_Prejudice%2C_the_first_edition.jpg/800px-Title_page_of_Pride_and_Prejudice%2C_the_first_edition.jpg", "Pride and Prejudice", 0 },
                    { 45, null, "Moby-Dick; or, The Whale is an 1851 novel by American writer Herman Melville.", false, "https://upload.wikimedia.org/wikipedia/commons/5/57/Moby-Dick_FE_title_page.jpg", "Moby-Dick", 0 },
                    { 46, null, "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/TheGreatGatsby_1925jacket.jpeg/800px-TheGreatGatsby_1925jacket.jpeg", "The Great Gatsby", 0 },
                    { 47, null, "War and Peace is a novel by the Russian author Leo Tolstoy, published from 1865 to 1869.", false, "https://upload.wikimedia.org/wikipedia/commons/8/8b/War-and-peace-book-cover.jpg", "War and Peace", 0 },
                    { 48, null, "Dune is a science fiction novel by American author Frank Herbert, originally published in 1965.", true, "https://upload.wikimedia.org/wikipedia/en/a/a8/Dune_1965_First_Edition.jpg", "Dune", 0 },
                    { 49, null, "Jane Eyre is a novel by English writer Charlotte Brontë, published under the pen name \"Currer Bell\", on 16 October 1847.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Jane_Eyre_title_page.jpg/800px-Jane_Eyre_title_page.jpg", "Jane Eyre", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 19.99m, 9.99m },
                    { 1, 3, 0m, 7.99m },
                    { 1, 4, 29.99m, 19.99m },
                    { 2, 2, 14.99m, 7.99m },
                    { 3, 2, 0m, 6.99m },
                    { 4, 2, 0m, 3.99m },
                    { 5, 2, 0m, 3.99m },
                    { 6, 2, 0m, 2.99m },
                    { 7, 2, 29.99m, 19.99m },
                    { 8, 3, 24.99m, 9.99m },
                    { 9, 2, 0m, 14.99m },
                    { 10, 1, 299m, 159.99m },
                    { 11, 1, 399m, 79.99m },
                    { 12, 2, 0m, 7.99m },
                    { 13, 3, 0m, 15.99m },
                    { 14, 2, 0m, 6.99m },
                    { 15, 3, 0m, 8.99m },
                    { 16, 4, 0m, 11.99m },
                    { 17, 2, 0m, 13.99m },
                    { 18, 2, 0m, 5.99m },
                    { 19, 4, 0m, 19.99m },
                    { 20, 3, 0m, 9.99m },
                    { 22, 2, 0m, 12.99m },
                    { 23, 2, 0m, 7.99m },
                    { 24, 3, 0m, 8.99m },
                    { 25, 2, 0m, 6.99m },
                    { 26, 4, 0m, 10.99m },
                    { 27, 2, 0m, 11.99m },
                    { 28, 4, 0m, 9.99m },
                    { 29, 3, 0m, 14.99m },
                    { 30, 2, 0m, 8.99m },
                    { 31, 2, 0m, 7.99m },
                    { 32, 4, 0m, 10.99m },
                    { 33, 2, 0m, 6.99m },
                    { 34, 3, 0m, 9.99m },
                    { 35, 2, 0m, 6.99m },
                    { 36, 4, 0m, 12.99m },
                    { 37, 2, 0m, 13.99m },
                    { 38, 3, 0m, 9.99m },
                    { 39, 4, 0m, 11.99m },
                    { 40, 2, 0m, 5.99m },
                    { 41, 3, 0m, 8.99m },
                    { 42, 2, 0m, 6.99m },
                    { 44, 3, 0m, 7.99m },
                    { 45, 2, 0m, 5.99m },
                    { 46, 3, 0m, 7.99m },
                    { 47, 4, 0m, 12.99m },
                    { 48, 3, 0m, 14.99m },
                    { 49, 2, 0m, 8.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductTypeId",
                table: "OrderItems",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
