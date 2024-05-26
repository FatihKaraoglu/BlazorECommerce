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
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "bi bi-rocket", "Science-Fiction", "science-fiction" },
                    { 2, "bi bi-magic", "Fantasy", "fantasy" },
                    { 3, "bi bi-heart-arrow", "Romance", "romance" },
                    { 4, "bi bi-lightning", "Thriller", "thriller" },
                    { 5, "bi bi-person-badge", "Biography", "biography" },
                    { 6, "bi bi-balloon", "Children", "children" },
                    { 7, "bi bi-journal-richtext", "Classic", "classic" },
                    { 8, "bi bi-egg-fried", "Cooking", "cooking" },
                    { 9, "bi bi-heart-pulse", "Health & Fitness", "health-fitness" },
                    { 10, "bi bi-brush", "Art", "art" },
                    { 11, "bi bi-lightbulb", "Science", "science" },
                    { 12, "bi bi-walking", "Sport", "sport" },
                    { 13, "bi bi-emoji-dizzy", "Horror", "horror" },
                    { 14, "bi bi-patch-check", "Self-Help", "self-help" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "Stream" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Neuromancer is a science fiction novel by American-Canadian writer William Gibson, published in 1984.", false, "https://upload.wikimedia.org/wikipedia/en/4/4b/Neuromancer_%28Book%29.jpg", "Neuromancer" },
                    { 2, 1, "Snow Crash is a science fiction novel by American writer Neal Stephenson, published in 1992.", false, "https://upload.wikimedia.org/wikipedia/en/d/d5/Snowcrash.jpg", "Snow Crash" },
                    { 3, 1, "Foundation is a science fiction novel by American writer Isaac Asimov, first published in 1951.", false, "https://upload.wikimedia.org/wikipedia/en/2/25/Foundation_gnome.jpg", "Foundation" },
                    { 4, 1, "Brave New World is a dystopian social science fiction novel by English author Aldous Huxley, published in 1932.", false, "https://upload.wikimedia.org/wikipedia/en/6/62/BraveNewWorld_FirstEdition.jpg", "Brave New World" },
                    { 5, 1, "Hyperion is a science fiction novel by American author Dan Simmons, published in 1989.", false, "https://upload.wikimedia.org/wikipedia/en/a/a1/Hyperion_cover.jpg", "Hyperion" },
                    { 6, 1, "Ender's Game is a 1985 military science fiction novel by American author Orson Scott Card.", false, "https://upload.wikimedia.org/wikipedia/en/9/95/Ender%27s_Game_cover_ISBN_0312932081.jpg", "Ender's Game" },
                    { 7, 1, "The Martian is a 2011 science fiction novel written by Andy Weir.", false, "https://upload.wikimedia.org/wikipedia/en/c/c3/The_Martian_2014.jpg", "The Martian" },
                    { 8, 1, "The Left Hand of Darkness is a science fiction novel by U.S. writer Ursula K. Le Guin, published in 1969.", false, "https://upload.wikimedia.org/wikipedia/en/2/29/TheLeftHandOfDarkness1stEd.jpg", "The Left Hand of Darkness" },
                    { 9, 1, "Stranger in a Strange Land is a 1961 science fiction novel by American author Robert A. Heinlein.", false, "https://upload.wikimedia.org/wikipedia/en/8/84/StrangerInaStrangeLand_Cover.jpg", "Stranger in a Strange Land" },
                    { 10, 1, "Do Androids Dream of Electric Sheep? is a science fiction novel by American writer Philip K. Dick, published in 1968.", false, "https://upload.wikimedia.org/wikipedia/en/e/ee/DoAndroidsDream.png", "Do Androids Dream of Electric Sheep?" },
                    { 11, 1, "The Road is a 2006 novel by American writer Cormac McCarthy. It is a post-apocalyptic story of a father and his young son.", false, "https://upload.wikimedia.org/wikipedia/en/6/6b/The-road.jpg", "The Road" },
                    { 12, 1, "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.", false, "https://upload.wikimedia.org/wikipedia/en/d/dc/The_Hunger_Games.jpg", "The Hunger Games" },
                    { 13, 1, "Ready Player Two is a 2020 science fiction novel by American author Ernest Cline.", false, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_Two.jpg", "Ready Player Two" },
                    { 14, 1, "Fahrenheit 451 is a 1953 dystopian novel by American writer Ray Bradbury.", false, "https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg", "Fahrenheit 451" },
                    { 15, 1, "The Handmaid's Tale is a dystopian novel by Canadian author Margaret Atwood, published in 1985.", false, "https://upload.wikimedia.org/wikipedia/en/b/ba/TheHandmaidsTale.jpg", "The Handmaid's Tale" },
                    { 16, 1, "Altered Carbon is a 2002 science fiction novel by the English author Richard K. Morgan.", false, "https://upload.wikimedia.org/wikipedia/en/b/b5/Altered_Carbon_%28cover%29.jpg", "Altered Carbon" },
                    { 17, 1, "Leviathan Wakes is a science fiction novel by James S. A. Corey, the first book in The Expanse series.", false, "https://upload.wikimedia.org/wikipedia/en/0/03/Leviathan_Wakes.jpg", "The Expanse: Leviathan Wakes" },
                    { 18, 1, "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", true, "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", "The Hobbit" },
                    { 19, 1, "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", false, "https://upload.wikimedia.org/wikipedia/en/9/93/AGameOfThrones.jpg", "A Game of Thrones" },
                    { 20, 1, "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J.K. Rowling.", false, "https://upload.wikimedia.org/wikipedia/en/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg", "Harry Potter and the Philosopher's Stone" },
                    { 21, 1, "The Name of the Wind is a heroic fantasy novel written by American author Patrick Rothfuss.", false, "https://upload.wikimedia.org/wikipedia/en/0/00/TheNameoftheWind_cover.jpg", "The Name of the Wind" },
                    { 22, 1, "The Way of Kings is an epic fantasy novel written by American author Brandon Sanderson.", false, "https://upload.wikimedia.org/wikipedia/en/8/81/TheWayOfKings.png", "The Way of Kings" },
                    { 23, 1, "Mistborn: The Final Empire is a fantasy novel written by American author Brandon Sanderson.", false, "https://upload.wikimedia.org/wikipedia/en/6/6d/Mistborn-cover.jpg", "Mistborn: The Final Empire" },
                    { 24, 1, "The Lies of Locke Lamora is a fantasy novel by American writer Scott Lynch.", false, "https://upload.wikimedia.org/wikipedia/en/4/4c/The_Lies_of_Locke_Lamora.jpg", "The Lies of Locke Lamora" },
                    { 25, 1, "Uprooted is a fantasy novel written by Naomi Novik.", false, "https://upload.wikimedia.org/wikipedia/en/a/a7/Uprooted_book_cover.jpg", "Uprooted" },
                    { 26, 1, "Circe is a 2018 novel by American writer Madeline Miller.", false, "https://upload.wikimedia.org/wikipedia/en/4/4b/Circe-novel.jpg", "Circe" },
                    { 27, 1, "The Night Circus is a fantasy novel by Erin Morgenstern.", false, "https://upload.wikimedia.org/wikipedia/en/3/35/TheNightCircus.jpg", "The Night Circus" },
                    { 28, 2, "Pride and Prejudice is a romantic novel by Jane Austen, first published in 1813.", true, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/PrideAndPrejudiceTitlePage.jpg/800px-PrideAndPrejudiceTitlePage.jpg", "Pride and Prejudice" },
                    { 29, 2, "Jane Eyre is a novel by English writer Charlotte Brontë, published under the pen name 'Currer Bell'.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Jane_Eyre_title_page.jpg/800px-Jane_Eyre_title_page.jpg", "Jane Eyre" },
                    { 30, 2, "Gone with the Wind is a novel by American writer Margaret Mitchell, first published in 1936.", false, "https://upload.wikimedia.org/wikipedia/en/6/6b/Gone_with_the_Wind_cover.jpg", "Gone with the Wind" },
                    { 31, 2, "Wuthering Heights is a novel by Emily Brontë, published in 1847 under her pseudonym 'Ellis Bell'.", false, "https://upload.wikimedia.org/wikipedia/commons/6/6e/Wuthering_Heights_first_edition.jpg", "Wuthering Heights" },
                    { 32, 2, "Anna Karenina is a novel by the Russian author Leo Tolstoy, first published in book form in 1878.", false, "https://upload.wikimedia.org/wikipedia/commons/d/d4/AnnaKareninaTitlePage.jpg", "Anna Karenina" },
                    { 33, 2, "Outlander is a series of historical romance science fiction novels by American author Diana Gabaldon.", false, "https://upload.wikimedia.org/wikipedia/en/3/3c/Outlander-1991.jpg", "Outlander" },
                    { 34, 2, "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.", false, "https://upload.wikimedia.org/wikipedia/en/8/8c/TheNotebook.jpg", "The Notebook" },
                    { 35, 2, "Me Before You is a romance novel written by Jojo Moyes.", false, "https://upload.wikimedia.org/wikipedia/en/f/fd/Me_Before_You.jpg", "Me Before You" },
                    { 36, 2, "The Fault in Our Stars is a novel by John Green.", false, "https://upload.wikimedia.org/wikipedia/en/a/a9/The_Fault_in_Our_Stars.jpg", "The Fault in Our Stars" },
                    { 37, 2, "Rebecca is a Gothic novel by English author Dame Daphne du Maurier.", false, "https://upload.wikimedia.org/wikipedia/en/f/f5/Rebecca_first_edition.jpg", "Rebecca" },
                    { 38, 3, "The Da Vinci Code is a mystery thriller novel by Dan Brown.", true, "https://upload.wikimedia.org/wikipedia/en/6/6b/DaVinciCode.jpg", "The Da Vinci Code" },
                    { 39, 3, "Gone Girl is a thriller novel by the writer Gillian Flynn.", false, "https://upload.wikimedia.org/wikipedia/en/0/05/Gone_Girl_Poster.jpg", "Gone Girl" },
                    { 40, 3, "The Girl with the Dragon Tattoo is a psychological thriller novel by Swedish author Stieg Larsson.", false, "https://upload.wikimedia.org/wikipedia/en/a/ae/M%C3%A4n_som_hatar_kvinnor.jpg", "The Girl with the Dragon Tattoo" },
                    { 41, 3, "The Silent Patient is a 2019 psychological thriller novel written by British-Cypriot author Alex Michaelides.", false, "https://upload.wikimedia.org/wikipedia/en/b/ba/The_Silent_Patient_%28Alex_Michaelides%29.png", "The Silent Patient" },
                    { 42, 3, "The Woman in the Window is a psychological thriller novel by American author A. J. Finn.", false, "https://upload.wikimedia.org/wikipedia/en/a/a0/The_Woman_in_the_Window_%28Finn_novel%29.jpg", "The Woman in the Window" },
                    { 43, 3, "Big Little Lies is a 2014 novel written by Liane Moriarty.", false, "https://upload.wikimedia.org/wikipedia/en/5/52/Big_Little_Lies.jpg", "Big Little Lies" },
                    { 44, 3, "The Girl on the Train is a 2015 psychological thriller novel by British author Paula Hawkins.", false, "https://upload.wikimedia.org/wikipedia/en/a/a8/The_Girl_on_the_Train_2015.jpg", "The Girl on the Train" },
                    { 45, 3, "Sharp Objects is the debut novel by American author Gillian Flynn.", false, "https://upload.wikimedia.org/wikipedia/en/3/32/Sharp_Objects_%28Flynn_novel%29.jpg", "Sharp Objects" },
                    { 46, 3, "The Girl with a Clock for a Heart is a 2014 novel by Peter Swanson.", false, "https://upload.wikimedia.org/wikipedia/en/0/0f/The_Girl_with_a_Clock_for_a_Heart.jpg", "The Girl with a Clock for a Heart" },
                    { 47, 3, "In the Woods is a 2007 mystery novel by Tana French.", false, "https://upload.wikimedia.org/wikipedia/en/4/42/In_the_Woods_%28French_novel%29.jpg", "In the Woods" },
                    { 48, 1, "Dune is a science fiction novel by American author Frank Herbert, originally published in 1965.", true, "https://upload.wikimedia.org/wikipedia/en/a/a8/Dune_1965_First_Edition.jpg", "Dune" }
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
                    { 4, 5, 0m, 3.99m },
                    { 4, 6, 0m, 9.99m },
                    { 4, 7, 0m, 19.99m },
                    { 5, 5, 0m, 3.99m },
                    { 6, 5, 0m, 2.99m },
                    { 7, 8, 29.99m, 19.99m },
                    { 7, 9, 0m, 69.99m },
                    { 7, 10, 59.99m, 49.99m },
                    { 8, 8, 24.99m, 9.99m },
                    { 9, 8, 0m, 14.99m },
                    { 10, 1, 299m, 159.99m },
                    { 11, 1, 399m, 79.99m }
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
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
