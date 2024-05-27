using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 2, "https://upload.wikimedia.org/wikipedia/en/a/a5/TheNightCircus.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { "Good Omens: The Nice and Accurate Prophecies of Agnes Nutter, Witch is a 1990 novel written by Neil Gaiman and Terry Pratchett.", false, "https://upload.wikimedia.org/wikipedia/en/1/1d/GoodOmensCover.jpg", "Good Omens" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "American Gods is a fantasy novel by British author Neil Gaiman.", "https://upload.wikimedia.org/wikipedia/en/a/a4/American_Gods.jpg", "American Gods" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Ocean at the End of the Lane is a 2013 novel by British author Neil Gaiman.", "https://upload.wikimedia.org/wikipedia/en/4/4e/Ocean_at_the_End_of_the_Lane_US_cover.jpg", "The Ocean at the End of the Lane" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Color of Magic is a 1983 fantasy novel by British writer Terry Pratchett, the first book in his Discworld series.", "https://upload.wikimedia.org/wikipedia/en/3/3d/The_Colour_of_Magic_%28cover_art%29.jpg", "The Color of Magic" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Mort is a fantasy novel by British writer Terry Pratchett, the fourth book in his Discworld series.", "https://upload.wikimedia.org/wikipedia/en/8/81/Mort_%28Terry_Pratchett_novel_-_cover_art%29.jpg", "Mort" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Small Gods is the thirteenth of Terry Pratchett's Discworld novels, published in 1992.", "https://upload.wikimedia.org/wikipedia/en/8/8c/Smallgods.jpg", "Small Gods" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Guards! Guards! is a fantasy novel by British writer Terry Pratchett, the eighth book in his Discworld series.", "https://upload.wikimedia.org/wikipedia/en/2/20/Guards-Guards-cover.jpg", "Guards! Guards!" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", "The Hobbit" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Fellowship of the Ring is the first of three volumes of the epic novel The Lord of the Rings by the English author J. R. R. Tolkien.", "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif", "The Fellowship of the Ring" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Two Towers is the second volume of J.R.R. Tolkien's high-fantasy novel The Lord of the Rings.", "https://upload.wikimedia.org/wikipedia/en/a/a1/The_Two_Towers_cover.gif", "The Two Towers" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 2, "The Return of the King is the third and final volume of J.R.R. Tolkien's The Lord of the Rings.", false, "https://upload.wikimedia.org/wikipedia/en/1/11/The_Return_of_the_King_cover.gif", "The Return of the King" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 2, "The Silmarillion is a collection of mythopoeic works by English writer J. R. R. Tolkien, edited and published posthumously by his son, Christopher Tolkien.", "https://upload.wikimedia.org/wikipedia/en/a/a4/The_Silmarillion_first_edition.jpg", "The Silmarillion" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "The Catcher in the Rye is a novel by J. D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951.", "https://upload.wikimedia.org/wikipedia/en/3/32/Rye_catcher.jpg", "The Catcher in the Rye" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "To Kill a Mockingbird is a novel by Harper Lee published in 1960.", "https://upload.wikimedia.org/wikipedia/en/7/79/To_Kill_a_Mockingbird.JPG", "To Kill a Mockingbird" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "Nineteen Eighty-Four, often referred to as 1984, is a dystopian social science fiction novel by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/en/c/c3/1984first.jpg", "1984" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "Animal Farm is an allegorical novella by George Orwell, first published in England on 17 August 1945.", "https://upload.wikimedia.org/wikipedia/commons/f/fb/Animal_Farm_-_1st_edition.jpg", "Animal Farm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Pride and Prejudice is a romantic novel of manners written by Jane Austen in 1813.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Title_page_of_Pride_and_Prejudice%2C_the_first_edition.jpg/800px-Title_page_of_Pride_and_Prejudice%2C_the_first_edition.jpg", "Pride and Prejudice" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "Moby-Dick; or, The Whale is an 1851 novel by American writer Herman Melville.", "https://upload.wikimedia.org/wikipedia/commons/5/57/Moby-Dick_FE_title_page.jpg", "Moby-Dick" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/TheGreatGatsby_1925jacket.jpeg/800px-TheGreatGatsby_1925jacket.jpeg", "The Great Gatsby" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 7, "War and Peace is a novel by the Russian author Leo Tolstoy, published from 1865 to 1869.", "https://upload.wikimedia.org/wikipedia/commons/8/8b/War-and-peace-book-cover.jpg", "War and Peace" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 49, 7, "Jane Eyre is a novel by English writer Charlotte Brontë, published under the pen name \"Currer Bell\", on 16 October 1847.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Jane_Eyre_title_page.jpg/800px-Jane_Eyre_title_page.jpg", "Jane Eyre" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CategoryId", "ImageUrl" },
                values: new object[] { 1, "https://upload.wikimedia.org/wikipedia/en/3/35/TheNightCircus.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { "Pride and Prejudice is a romantic novel by Jane Austen, first published in 1813.", true, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/PrideAndPrejudiceTitlePage.jpg/800px-PrideAndPrejudiceTitlePage.jpg", "Pride and Prejudice" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Jane Eyre is a novel by English writer Charlotte Brontë, published under the pen name 'Currer Bell'.", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Jane_Eyre_title_page.jpg/800px-Jane_Eyre_title_page.jpg", "Jane Eyre" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Gone with the Wind is a novel by American writer Margaret Mitchell, first published in 1936.", "https://upload.wikimedia.org/wikipedia/en/6/6b/Gone_with_the_Wind_cover.jpg", "Gone with the Wind" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Wuthering Heights is a novel by Emily Brontë, published in 1847 under her pseudonym 'Ellis Bell'.", "https://upload.wikimedia.org/wikipedia/commons/6/6e/Wuthering_Heights_first_edition.jpg", "Wuthering Heights" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Anna Karenina is a novel by the Russian author Leo Tolstoy, first published in book form in 1878.", "https://upload.wikimedia.org/wikipedia/commons/d/d4/AnnaKareninaTitlePage.jpg", "Anna Karenina" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Outlander is a series of historical romance science fiction novels by American author Diana Gabaldon.", "https://upload.wikimedia.org/wikipedia/en/3/3c/Outlander-1991.jpg", "Outlander" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.", "https://upload.wikimedia.org/wikipedia/en/8/8c/TheNotebook.jpg", "The Notebook" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Me Before You is a romance novel written by Jojo Moyes.", "https://upload.wikimedia.org/wikipedia/en/f/fd/Me_Before_You.jpg", "Me Before You" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Fault in Our Stars is a novel by John Green.", "https://upload.wikimedia.org/wikipedia/en/a/a9/The_Fault_in_Our_Stars.jpg", "The Fault in Our Stars" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Rebecca is a Gothic novel by English author Dame Daphne du Maurier.", "https://upload.wikimedia.org/wikipedia/en/f/f5/Rebecca_first_edition.jpg", "Rebecca" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 3, "The Da Vinci Code is a mystery thriller novel by Dan Brown.", true, "https://upload.wikimedia.org/wikipedia/en/6/6b/DaVinciCode.jpg", "The Da Vinci Code" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "Gone Girl is a thriller novel by the writer Gillian Flynn.", "https://upload.wikimedia.org/wikipedia/en/0/05/Gone_Girl_Poster.jpg", "Gone Girl" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "The Girl with the Dragon Tattoo is a psychological thriller novel by Swedish author Stieg Larsson.", "https://upload.wikimedia.org/wikipedia/en/a/ae/M%C3%A4n_som_hatar_kvinnor.jpg", "The Girl with the Dragon Tattoo" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "The Silent Patient is a 2019 psychological thriller novel written by British-Cypriot author Alex Michaelides.", "https://upload.wikimedia.org/wikipedia/en/b/ba/The_Silent_Patient_%28Alex_Michaelides%29.png", "The Silent Patient" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "The Woman in the Window is a psychological thriller novel by American author A. J. Finn.", "https://upload.wikimedia.org/wikipedia/en/a/a0/The_Woman_in_the_Window_%28Finn_novel%29.jpg", "The Woman in the Window" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "Big Little Lies is a 2014 novel written by Liane Moriarty.", "https://upload.wikimedia.org/wikipedia/en/5/52/Big_Little_Lies.jpg", "Big Little Lies" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Girl on the Train is a 2015 psychological thriller novel by British author Paula Hawkins.", "https://upload.wikimedia.org/wikipedia/en/a/a8/The_Girl_on_the_Train_2015.jpg", "The Girl on the Train" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "Sharp Objects is the debut novel by American author Gillian Flynn.", "https://upload.wikimedia.org/wikipedia/en/3/32/Sharp_Objects_%28Flynn_novel%29.jpg", "Sharp Objects" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "The Girl with a Clock for a Heart is a 2014 novel by Peter Swanson.", "https://upload.wikimedia.org/wikipedia/en/0/0f/The_Girl_with_a_Clock_for_a_Heart.jpg", "The Girl with a Clock for a Heart" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, "In the Woods is a 2007 mystery novel by Tana French.", "https://upload.wikimedia.org/wikipedia/en/4/42/In_the_Woods_%28French_novel%29.jpg", "In the Woods" });
        }
    }
}
