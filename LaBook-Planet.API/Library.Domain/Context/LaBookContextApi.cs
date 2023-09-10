using LaBook_Planet.API.Library.Domain.Enums;
using LaBook_Planet.API.Library.Domain.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.SourceControl.WebApi;

namespace LaBook_Planet.API.Library.Domain.Context
{
    public class LaBookContextApi : DbContext
    {
        public LaBookContextApi(DbContextOptions<LaBookContextApi> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = "1", Name = "Fiction", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category { Id = "2", Name = "Mystery", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                // Add more categories...
            );

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = "1", CategoryId = "1", Name = "Science Fiction", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Genre { Id = "2", CategoryId = "1", Name = "Fantasy", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                // Add more genres...
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = "9BD6AB79-4A04-47FF-B831-25D620A1407B",
                    Title = "Bröderna Lejonhjärta",
                    Description = "A Swedish fantasy novel...",
                    Author = "Astrid Lindgren",
                    AvailableCopies = 10,
                    GenreId = "1", 
                    Language = "Swedish",
                    RatingValue = (int)Rating.Star4,
                    ISBN = "9789129688313",
                    DatePublished = DateTime.Parse("2013-09-26"),
                    NumOfPages = 250,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Book
                {
                    Id = "B9C7241B-6CAB-4350-9421-2D8EDCC8C98A",
                    Title = "The Fellowship of the Ring",
                    Description = "The first novel in J.R.R. Tolkien's epic...",
                    Author = "J. R. R. Tolkien",
                    AvailableCopies = 15,
                    GenreId = "2", 
                    Language = "English",
                    RatingValue = (int)Rating.Star5,
                    ISBN = "9780261102354",
                    DatePublished = DateTime.Parse("1991-07-04"),
                    NumOfPages = 400,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },

               new Book
               {
                   Id = "D66CFA62-A1E7-45C0-841E-7BF3E83CEEBD",
                   Title = "The Fellowship of the Ring",
                   Description = "The first book in J.R.R. Tolkien's epic fantasy series 'The Lord of the Rings'.",
                   Author = "J.R.R. Tolkien",
                   AvailableCopies = 10,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9780261102354",
                   DatePublished = DateTime.Parse("1991-07-04"),
                   NumOfPages = 423,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


               new Book
               {
                   Id = "480939AA-E9CE-4B19-86D9-69127424F254",
                   Title = "The Holy Bible",
                   Description = "The sacred scripture of Christianity, consisting of the Old Testament and the New Testament.",
                   Author = "Multiple Authors",
                   AvailableCopies = 50,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 5, 
                   ISBN = "9780007103072",
                   DatePublished = DateTime.Parse("1611-01-01"), 
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "DAAAA97F-9466-43D8-8447-4C23E90D8752",
                    Title = "Rich Dad Poor Dad",
                    Description = "Rich Dad Poor Dad is a personal finance classic written by Robert Kiyosaki. It explores the differences in mindset and financial strategies between the author's 'rich dad' and 'poor dad'.",
                    Author = "Robert T. Kiyosaki",
                    AvailableCopies = 30,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781612680019",
                    DatePublished = DateTime.Parse("1997-04-01"),
                    NumOfPages = 207, 
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "5791E5A1-EE69-4B2B-A997-96DEB565F6C0",
                    Title = "God's Generals",
                    Description = "God's Generals is a collection of biographies written by Roberts Liardon, chronicling the lives and ministries of various influential Christian leaders throughout history.",
                    Author = "Roberts Liardon",
                    AvailableCopies = 20,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781603740906",
                    DatePublished = DateTime.Parse("2003-05-01"),
                    NumOfPages = 416,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }


                

            );

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = "1",
                    BookId = "1",
                    Title = "A Fantastic Read",
                    Text = "I loved every moment of this book...",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },

                new Review
                {
                    Id = "2",
                    BookId = "2",
                    Title = "An Epic Adventure",
                    Text = "Tolkien's masterpiece continues to captivate...",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
          
            );

            
        }
    }
}
