using BlazorECommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().
                HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<ProductVariant>().
                HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<OrderItem>().
             HasKey(oi => new { oi.OrderId, oi.ProductId,  oi.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                   new ProductType { Id = 1, Name = "Default" },
                   new ProductType { Id = 2, Name = "Paperback" },
                   new ProductType { Id = 3, Name = "E-Book" },
                   new ProductType { Id = 4, Name = "Audiobook" },
                   new ProductType { Id = 5, Name = "Stream" },
                   new ProductType { Id = 6, Name = "Blu-ray" },
                   new ProductType { Id = 7, Name = "VHS" },
                   new ProductType { Id = 8, Name = "PC" },
                   new ProductType { Id = 9, Name = "PlayStation" },
                   new ProductType { Id = 10, Name = "Xbox" }
               );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 3.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 3.99m,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 2.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 69.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 49.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 9.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 1,
                    Price = 159.99m,
                    OriginalPrice = 299m
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    Price = 79.99m,
                    OriginalPrice = 399m
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Science-Fiction", Url = "science-fiction", Icon = "bi bi-rocket" },
                new Category { Id = 2, Name = "Fantasy", Url = "fantasy", Icon = "bi bi-magic" },
                new Category { Id = 3, Name = "Romance", Url = "romance", Icon = "bi bi-heart-arrow" },
                new Category { Id = 4, Name = "Thriller", Url = "thriller", Icon = "bi bi-lightning" },
                new Category { Id = 5, Name = "Biography", Url = "biography", Icon = "bi bi-person-badge" },
                new Category { Id = 6, Name = "Children", Url = "children", Icon = "bi bi-balloon" },
                new Category { Id = 7, Name = "Classic", Url = "classic", Icon = "bi bi-journal-richtext" },
                new Category { Id = 8, Name = "Cooking", Url = "cooking", Icon = "bi bi-egg-fried" },
                new Category { Id = 9, Name = "Health & Fitness", Url = "health-fitness", Icon = "bi bi-heart-pulse" },
                new Category { Id = 10, Name = "Art", Url = "art", Icon = "bi bi-brush" },
                new Category { Id = 11, Name = "Science", Url = "science", Icon = "bi bi-lightbulb" },
                new Category { Id = 12, Name = "Sport", Url = "sport", Icon = "bi bi-walking" },
                new Category { Id = 13, Name = "Horror", Url = "horror", Icon = "bi bi-emoji-dizzy" },
                new Category { Id = 14, Name = "Self-Help", Url = "self-help", Icon = "bi bi-patch-check" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 48, Title = "Dune", Description = "Dune is a science fiction novel by American author Frank Herbert, originally published in 1965.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a8/Dune_1965_First_Edition.jpg", CategoryId = 1, Featured = true },
                new Product { Id = 1, Title = "Neuromancer", Description = "Neuromancer is a science fiction novel by American-Canadian writer William Gibson, published in 1984.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4b/Neuromancer_%28Book%29.jpg", CategoryId = 1 },
                new Product { Id = 2, Title = "Snow Crash", Description = "Snow Crash is a science fiction novel by American writer Neal Stephenson, published in 1992.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Snowcrash.jpg", CategoryId = 1 },
                new Product { Id = 3, Title = "Foundation", Description = "Foundation is a science fiction novel by American writer Isaac Asimov, first published in 1951.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Foundation_gnome.jpg", CategoryId = 1 },
                new Product { Id = 4, Title = "Brave New World", Description = "Brave New World is a dystopian social science fiction novel by English author Aldous Huxley, published in 1932.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/62/BraveNewWorld_FirstEdition.jpg", CategoryId = 1 },
                new Product { Id = 5, Title = "Hyperion", Description = "Hyperion is a science fiction novel by American author Dan Simmons, published in 1989.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a1/Hyperion_cover.jpg", CategoryId = 1 },
                new Product { Id = 6, Title = "Ender's Game", Description = "Ender's Game is a 1985 military science fiction novel by American author Orson Scott Card.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/95/Ender%27s_Game_cover_ISBN_0312932081.jpg", CategoryId = 1 },
                new Product { Id = 7, Title = "The Martian", Description = "The Martian is a 2011 science fiction novel written by Andy Weir.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c3/The_Martian_2014.jpg", CategoryId = 1 },
                new Product { Id = 8, Title = "The Left Hand of Darkness", Description = "The Left Hand of Darkness is a science fiction novel by U.S. writer Ursula K. Le Guin, published in 1969.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/29/TheLeftHandOfDarkness1stEd.jpg", CategoryId = 1 },
                new Product { Id = 9, Title = "Stranger in a Strange Land", Description = "Stranger in a Strange Land is a 1961 science fiction novel by American author Robert A. Heinlein.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/84/StrangerInaStrangeLand_Cover.jpg", CategoryId = 1 },
                new Product { Id = 10, Title = "Do Androids Dream of Electric Sheep?", Description = "Do Androids Dream of Electric Sheep? is a science fiction novel by American writer Philip K. Dick, published in 1968.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ee/DoAndroidsDream.png", CategoryId = 1 },
                new Product { Id = 11, Title = "The Road", Description = "The Road is a 2006 novel by American writer Cormac McCarthy. It is a post-apocalyptic story of a father and his young son.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/The-road.jpg", CategoryId = 1 },
                new Product { Id = 12, Title = "The Hunger Games", Description = "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/dc/The_Hunger_Games.jpg", CategoryId = 1 },
                new Product { Id = 13, Title = "Ready Player Two", Description = "Ready Player Two is a 2020 science fiction novel by American author Ernest Cline.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_Two.jpg", CategoryId = 1 },
                new Product { Id = 14, Title = "Fahrenheit 451", Description = "Fahrenheit 451 is a 1953 dystopian novel by American writer Ray Bradbury.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg", CategoryId = 1 },
                new Product { Id = 15, Title = "The Handmaid's Tale", Description = "The Handmaid's Tale is a dystopian novel by Canadian author Margaret Atwood, published in 1985.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/ba/TheHandmaidsTale.jpg", CategoryId = 1 },
                new Product { Id = 16, Title = "Altered Carbon", Description = "Altered Carbon is a 2002 science fiction novel by the English author Richard K. Morgan.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b5/Altered_Carbon_%28cover%29.jpg", CategoryId = 1 },
                new Product { Id = 17, Title = "The Expanse: Leviathan Wakes", Description = "Leviathan Wakes is a science fiction novel by James S. A. Corey, the first book in The Expanse series.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Leviathan_Wakes.jpg", CategoryId = 1 },
                new Product { Id = 18, Title = "The Hobbit", Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", CategoryId = 1, Featured = true },
                new Product { Id = 19, Title = "A Game of Thrones", Description = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/93/AGameOfThrones.jpg", CategoryId = 1 },
                new Product { Id = 20, Title = "Harry Potter and the Philosopher's Stone", Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J.K. Rowling.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg", CategoryId = 1 },
                new Product { Id = 21, Title = "The Name of the Wind", Description = "The Name of the Wind is a heroic fantasy novel written by American author Patrick Rothfuss.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/TheNameoftheWind_cover.jpg", CategoryId = 1 },
                new Product { Id = 22, Title = "The Way of Kings", Description = "The Way of Kings is an epic fantasy novel written by American author Brandon Sanderson.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/TheWayOfKings.png", CategoryId = 1 },
                new Product { Id = 23, Title = "Mistborn: The Final Empire", Description = "Mistborn: The Final Empire is a fantasy novel written by American author Brandon Sanderson.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6d/Mistborn-cover.jpg", CategoryId = 1 },
                new Product { Id = 24, Title = "The Lies of Locke Lamora", Description = "The Lies of Locke Lamora is a fantasy novel by American writer Scott Lynch.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4c/The_Lies_of_Locke_Lamora.jpg", CategoryId = 1 },
                new Product { Id = 25, Title = "Uprooted", Description = "Uprooted is a fantasy novel written by Naomi Novik.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a7/Uprooted_book_cover.jpg", CategoryId = 1 },
                new Product { Id = 26, Title = "Circe", Description = "Circe is a 2018 novel by American writer Madeline Miller.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4b/Circe-novel.jpg", CategoryId = 1 },
                new Product { Id = 27, Title = "The Night Circus", Description = "The Night Circus is a fantasy novel by Erin Morgenstern.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/35/TheNightCircus.jpg", CategoryId = 1 },
                new Product { Id = 28, Title = "Pride and Prejudice", Description = "Pride and Prejudice is a romantic novel by Jane Austen, first published in 1813.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/PrideAndPrejudiceTitlePage.jpg/800px-PrideAndPrejudiceTitlePage.jpg", CategoryId = 2, Featured = true },
                new Product { Id = 29, Title = "Jane Eyre", Description = "Jane Eyre is a novel by English writer Charlotte Brontë, published under the pen name 'Currer Bell'.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Jane_Eyre_title_page.jpg/800px-Jane_Eyre_title_page.jpg", CategoryId = 2 },
                new Product { Id = 30, Title = "Gone with the Wind", Description = "Gone with the Wind is a novel by American writer Margaret Mitchell, first published in 1936.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/Gone_with_the_Wind_cover.jpg", CategoryId = 2 },
                new Product { Id = 31, Title = "Wuthering Heights", Description = "Wuthering Heights is a novel by Emily Brontë, published in 1847 under her pseudonym 'Ellis Bell'.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6e/Wuthering_Heights_first_edition.jpg", CategoryId = 2 },
                new Product { Id = 32, Title = "Anna Karenina", Description = "Anna Karenina is a novel by the Russian author Leo Tolstoy, first published in book form in 1878.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d4/AnnaKareninaTitlePage.jpg", CategoryId = 2 },
                new Product { Id = 33, Title = "Outlander", Description = "Outlander is a series of historical romance science fiction novels by American author Diana Gabaldon.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3c/Outlander-1991.jpg", CategoryId = 2 },
                new Product { Id = 34, Title = "The Notebook", Description = "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8c/TheNotebook.jpg", CategoryId = 2 },
                new Product { Id = 35, Title = "Me Before You", Description = "Me Before You is a romance novel written by Jojo Moyes.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fd/Me_Before_You.jpg", CategoryId = 2 },
                new Product { Id = 36, Title = "The Fault in Our Stars", Description = "The Fault in Our Stars is a novel by John Green.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a9/The_Fault_in_Our_Stars.jpg", CategoryId = 2 },
                new Product { Id = 37, Title = "Rebecca", Description = "Rebecca is a Gothic novel by English author Dame Daphne du Maurier.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f5/Rebecca_first_edition.jpg", CategoryId = 2 },
                new Product { Id = 38, Title = "The Da Vinci Code", Description = "The Da Vinci Code is a mystery thriller novel by Dan Brown.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6b/DaVinciCode.jpg", CategoryId = 3, Featured = true },
                new Product { Id = 39, Title = "Gone Girl", Description = "Gone Girl is a thriller novel by the writer Gillian Flynn.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/05/Gone_Girl_Poster.jpg", CategoryId = 3 },
                new Product { Id = 40, Title = "The Girl with the Dragon Tattoo", Description = "The Girl with the Dragon Tattoo is a psychological thriller novel by Swedish author Stieg Larsson.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/ae/M%C3%A4n_som_hatar_kvinnor.jpg", CategoryId = 3 },
                new Product { Id = 41, Title = "The Silent Patient", Description = "The Silent Patient is a 2019 psychological thriller novel written by British-Cypriot author Alex Michaelides.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/ba/The_Silent_Patient_%28Alex_Michaelides%29.png", CategoryId = 3 },
                new Product { Id = 42, Title = "The Woman in the Window", Description = "The Woman in the Window is a psychological thriller novel by American author A. J. Finn.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a0/The_Woman_in_the_Window_%28Finn_novel%29.jpg", CategoryId = 3 },
                new Product { Id = 43, Title = "Big Little Lies", Description = "Big Little Lies is a 2014 novel written by Liane Moriarty.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/52/Big_Little_Lies.jpg", CategoryId = 3 },
                new Product { Id = 44, Title = "The Girl on the Train", Description = "The Girl on the Train is a 2015 psychological thriller novel by British author Paula Hawkins.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a8/The_Girl_on_the_Train_2015.jpg", CategoryId = 3 },
                new Product { Id = 45, Title = "Sharp Objects", Description = "Sharp Objects is the debut novel by American author Gillian Flynn.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/32/Sharp_Objects_%28Flynn_novel%29.jpg", CategoryId = 3 },
                new Product { Id = 46, Title = "The Girl with a Clock for a Heart", Description = "The Girl with a Clock for a Heart is a 2014 novel by Peter Swanson.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0f/The_Girl_with_a_Clock_for_a_Heart.jpg", CategoryId = 3 },
                new Product { Id = 47, Title = "In the Woods", Description = "In the Woods is a 2007 mystery novel by Tana French.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/42/In_the_Woods_%28French_novel%29.jpg", CategoryId = 3 }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }








    }
}
