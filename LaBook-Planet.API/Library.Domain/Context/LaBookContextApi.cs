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
                    BookId = "1",
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
                    BookId = "2",
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
                   BookId = "3",
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
                   BookId = "4",
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
                    BookId = "5",
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
                    BookId = "6",
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
                },


                new Book
                {
                    Id = "7F9DB138-7CA3-41B7-8997-77B67A526AFA",
                    BookId = "7",
                    Title = "Good Morning, Holy Spirit",
                    Description = "Good Morning, Holy Spirit is a book by Benny Hinn that describes his personal journey and relationship with the Holy Spirit. It offers insights and teachings on how to experience the presence and power of the Holy Spirit in daily life.",
                    Author = "Benny Hinn",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9780785261261",
                    DatePublished = DateTime.Parse("1990-05-07"),
                    NumOfPages = 208,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "FF4C6D1F-DF38-4BA9-96B7-B32B97EFE376",
                   BookId = "8",
                   Title = "Power of the Mind by Pastor Chris",
                   Description = "Power of the Mind by Pastor Chris is a transformative book that delves into the incredible capabilities of the human mind as understood from a spiritual perspective. It explores how harnessing the power of the mind can lead to positive changes in one's life and spiritual journey.",
                   Author = "Pastor Chris Oyakhilome",
                   AvailableCopies = 50,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 5, 
                   ISBN = "9780987294403", 
                   DatePublished = DateTime.Parse("2010-09-01"),
                   NumOfPages = 240,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "E7C22583-80B9-4EAE-BDDB-A642A11716C9",
                    BookId = "9",
                    Title = "Entrapment",
                    Description = "Entrapment is a thrilling novel that follows the story of intrigue and suspense as a group of skilled individuals come together to execute an elaborate heist. With unexpected twists and turns, the book keeps readers on the edge of their seats from start to finish.",
                    Author = "Author's Name", 
                    AvailableCopies = 20,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781234567890",
                    DatePublished = DateTime.Parse("2022-05-15"),
                    NumOfPages = 320,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "E7C22583-80B9-4EAE-BDDB-A642A11716C9",
                    BookId = "10",
                    Title = "Entrapment",
                    Description = "Entrapment is a thrilling novel by Aleatha Romig that captivates readers with its suspenseful plot and well-developed characters. Dive into a world of mystery and intrigue as secrets unravel and alliances shift. With Aleatha Romig's signature writing style, this book keeps you guessing until the very end.",
                    Author = "Aleatha Romig",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781234567890", 
                    DatePublished = DateTime.Parse("2022-08-10"),
                    NumOfPages = 400,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "F6C4A34D-1A2B-4CC9-8B3C-9FA42B7F7E7A",
                    BookId = "11",
                    Title = "Married to the Devil's Son",
                    Description = "In 'Married to the Devil's Son,' readers are drawn into a world of forbidden love and intrigue. This gripping story follows the tumultuous relationship between two individuals from rival families, and their journey to find love against all odds. With a captivating narrative and complex characters, this book explores themes of passion, loyalty, and sacrifice.",
                    Author = "Jennife Sierra",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9782345678901", 
                    DatePublished = DateTime.Parse("2021-05-15"),
                    NumOfPages = 320,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "5E08C67B-06C9-4D04-A9A9-89E9F16C87E3",
                    BookId = "12",
                    Title = "Mermaid Tales",
                    Description = "Dive into the enchanting world of 'Mermaid Tales,' where mythical creatures and underwater adventures await. This imaginative tale follows the journey of a young mermaid as she embarks on a quest to uncover the secrets of the deep sea. With vibrant storytelling and captivating illustrations, 'Mermaid Tales' is a delightful read for readers of all ages.",
                    Author = "Isabella Waters",
                    AvailableCopies = 12,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 5, 
                    ISBN = "9781234567890", 
                    DatePublished = DateTime.Parse("2022-08-10"),
                    NumOfPages = 128,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "A2B8F57D-AD5F-4E95-8E96-52667B6E20EB",
                    BookId = "13",
                    Title = "Gifts of the Spirit",
                    Description = "Delve into the realm of spiritual gifts and explore the divine manifestations that enrich our lives. 'Gifts of the Spirit' provides profound insights into the supernatural abilities bestowed upon believers. With wisdom and guidance, this book offers a deeper understanding of how these gifts operate and their significance in fostering spiritual growth.",
                    Author = "Rebecca Divine",
                    AvailableCopies = 8,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9789876543210", 
                    DatePublished = DateTime.Parse("2021-05-20"),
                    NumOfPages = 240,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "F37F3655-B93D-4823-9F52-3E2E39B6B6C2",
                   BookId = "14",
                   Title = "Men Are from Mars, Women Are from Venus",
                   Description = "Explore the differences in communication, emotional needs, and behavior between men and women in this classic relationship guide. 'Men Are from Mars, Women Are from Venus' provides valuable insights into understanding and improving relationships, offering practical advice for bridging the gap between the genders and nurturing healthier connections.",
                   Author = "John Gray, Ph.D.",
                   AvailableCopies = 12,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9780060574215", 
                   DatePublished = DateTime.Parse("1992-04-23"),
                   NumOfPages = 320,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "C9A32F25-68F3-4B2F-9076-605F8A4F7C6B",
                    BookId = "15",
                    Title = "Rookie Cooking",
                    Description = "Embark on a culinary journey as a beginner cook with 'Rookie Cooking.' This book is packed with easy-to-follow recipes and cooking tips designed to help newcomers to the kitchen build their confidence and develop essential cooking skills. From basic knife techniques to mastering simple dishes, 'Rookie Cooking' is the perfect guide to start your cooking adventure.",
                    Author = "Sarah Johnson",
                    AvailableCopies = 8,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 3, 
                    ISBN = "9781523501183", 
                    DatePublished = DateTime.Parse("2021-08-15"),
                    NumOfPages = 200,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "D9B58215-721B-492C-A955-8E1B89F2EB3F",
                    BookId = "16",
                    Title = "Lost Princess",
                    Description = "Embark on an enchanting journey with the 'Lost Princess' as she navigates a world filled with magic, mystery, and adventure. Written by acclaimed author Emily Roberts, this fantasy novel follows the story of a young princess who discovers her hidden powers and sets out on a quest to save her kingdom from an ancient evil. With captivating characters and vivid world-building, 'Lost Princess' is a tale that will capture the hearts of readers young and old.",
                    Author = "Emily Roberts",
                    AvailableCopies = 5,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781452168443", 
                    DatePublished = DateTime.Parse("2022-03-10"),
                    NumOfPages = 320,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "9C0C2617-7E9A-45B6-8F2A-65A4FDE2453E",
                    BookId = "17",
                    Title = "Chef at Home",
                    Description = "Unleash your inner culinary artist with 'Chef at Home.' This comprehensive cookbook by renowned chef Sarah Miller provides a collection of delicious and easy-to-follow recipes that you can prepare right in your own kitchen. Whether you're a seasoned home cook or a beginner, this book is packed with tips, techniques, and mouthwatering dishes that will elevate your cooking skills. From savory entrees to decadent desserts, 'Chef at Home' has something for every palate.",
                    Author = "Sarah Miller",
                    AvailableCopies = 8,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781789096570", 
                    DatePublished = DateTime.Parse("2021-08-15"),
                    NumOfPages = 256,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "B8FD14C3-3D07-4A3B-BF16-2F870E1850E6",
                    BookId = "18",
                    Title = "The Best Freezer Cook Book",
                    Description = "Discover the ultimate guide to meal prepping with 'The Best Freezer Cook Book.' Author Jessica Anderson offers a diverse collection of freezer-friendly recipes that are designed to save you time and make meal planning a breeze. From make-ahead breakfasts to hearty dinners and sweet treats, this cookbook covers it all. Whether you're a busy parent or someone looking to streamline your cooking routine, you'll find creative and delicious recipes that can be prepared in advance and stored in your freezer until you're ready to enjoy them.",
                    Author = "Jessica Anderson",
                    AvailableCopies = 12,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781526308675",
                    DatePublished = DateTime.Parse("2022-03-10"),
                    NumOfPages = 192,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "F0A62A9B-7C0F-428C-B39B-C7C0EDB54E78",
                    BookId = "19",
                    Title = "Valeria",
                    Description = "Dive into the captivating world of 'Valeria,' a novel that weaves together romance, mystery, and suspense. Follow the journey of the titular character, Valeria, as she navigates through life's challenges, unexpected twists, and intriguing relationships. This book promises to keep readers engaged from the first page to the last, as they uncover the secrets that lie beneath the surface.",
                    Author = "Isabel Allende",
                    AvailableCopies = 8,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9780063022767", 
                    DatePublished = DateTime.Parse("2023-06-15"),
                    NumOfPages = 320,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "C3A9F32E-8C5B-4C8E-A1EE-9F2E607B14FD",
                    BookId = "20",
                    Title = "The Time Opener",
                    Description = "Embark on a thrilling journey through time and space with 'The Time Opener.' This science fiction masterpiece takes readers on an epic adventure, exploring the boundaries of time travel, alternate realities, and the consequences of tampering with the fabric of existence. As the characters grapple with complex ethical dilemmas and mind-bending paradoxes, you'll be immersed in a world of wonder and suspense.",
                    Author = "Michael Crichton",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9780525945714", 
                    DatePublished = DateTime.Parse("2023-08-27"),
                    NumOfPages = 450,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "E6F1B380-8E88-4C1D-A00C-2A67F23C298E",
                   BookId = "21",
                   Title = "Traveler: The New Era",
                   Description = "Dive into the captivating world of 'Traveler: The New Era.' In this fantasy epic, follow the journey of a young traveler who discovers an ancient prophecy that foretells the rise of a new era. Filled with magical creatures, mythical landscapes, and a battle between light and darkness, this book will transport you to a realm of adventure and heroism.",
                   Author = "Sarah J. Maas",
                   AvailableCopies = 15,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9781982116141", 
                   DatePublished = DateTime.Parse("2023-08-27"),
                   NumOfPages = 560,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "8B9A2D7E-4C74-4C88-A3E3-5F1C4DD2A7A7",
                    BookId = "22",
                    Title = "C# in a Nutshell",
                    Description = "Unlock the power of C# with 'C# in a Nutshell.' This comprehensive guide covers everything from the basics of the C# language to advanced topics like LINQ, asynchronous programming, and more. Whether you're a beginner or an experienced developer, this book will serve as an indispensable reference for all your C# programming needs.",
                    Author = "Joseph Albahari",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    RatingValue = 5, 
                    ISBN = "9781491927069",
                    DatePublished = DateTime.Parse("2022-05-15"),
                    NumOfPages = 1000,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "E76F6E08-532C-4D3C-A889-2D6E8533DB44",
                    BookId = "23",
                    Title = "Object Oriented Programming using C#",
                    Description = "Master the art of object-oriented programming with C# through this comprehensive guide. Learn about classes, objects, inheritance, polymorphism, encapsulation, and more. This book is designed to help beginners and intermediate programmers understand and apply the principles of object-oriented programming using C#.",
                    Author = "John Smith",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781234567890", 
                    DatePublished = DateTime.Parse("2021-09-01"),
                    NumOfPages = 400,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "9A4C6A9D-98EB-4F63-AEF2-3E545A3DFD22",
                    BookId = "24",
                    Title = "Microsoft Visual C# Step by Step",
                    Description = "Learn C# programming from scratch with the comprehensive guide from Microsoft Press. This book covers essential concepts, syntax, and techniques for building Windows applications using C# and Visual Studio. Ideal for beginners and those looking to expand their C# skills.",
                    Author = "John Doe",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9789876543210", 
                    DatePublished = DateTime.Parse("2022-05-15"),
                    NumOfPages = 500,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "A2E19A84-9B3F-4B71-85E9-5B680F0F74E5",
                    BookId = "25",
                    Title = "Super Foods: The Healthiest Foods in the Planet",
                    Description = "Discover the world's healthiest foods and their benefits with this comprehensive guide. Learn about nutrient-rich foods that can boost your overall health and well-being. This book provides insights into superfoods, their nutritional value, and how to incorporate them into your diet.",
                    Author = "Jane Smith",
                    AvailableCopies = 5,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781234567890", 
                    DatePublished = DateTime.Parse("2021-10-20"),
                    NumOfPages = 300,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "B1EDE5B0-2875-4E6E-B6B9-15D5E71EDF25",
                   BookId = "26",
                   Title = "Good Health in the 21st Century",
                   Description = "Navigate the complexities of maintaining good health in the modern era. This book explores the challenges and opportunities for staying healthy in the 21st century. Discover practical tips, insights, and strategies to enhance your well-being and lead a balanced lifestyle.",
                   Author = "Emily Johnson",
                   AvailableCopies = 10,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9789876543210", 
                   DatePublished = DateTime.Parse("2022-05-15"),
                   NumOfPages = 250,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


               new Book
               {
                   Id = "F1A9B82E-3D4E-47F0-9C78-8B11E5E842D1",
                   BookId = "27",
                   Title = "The Men's Health Big Book",
                   Description = "Unlock your full potential with The Men's Health Big Book. Packed with expert advice, workouts, nutrition tips, and more, this comprehensive guide is designed to help men achieve their fitness and wellness goals. Whether you're a beginner or a seasoned fitness enthusiast, this book has the tools you need to build a stronger, healthier body.",
                   Author = "John Smith",
                   AvailableCopies = 15,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9781234567890", 
                   DatePublished = DateTime.Parse("2021-09-10"),
                   NumOfPages = 400,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "9E8F31A0-EB63-4A8D-9C5B-3A6F6C20C8D9",
                    BookId = "28",
                    Title = "Health and Fitness by Harcourt",
                    Description = "Discover the keys to a healthier and fitter lifestyle with 'Health and Fitness' by Harcourt. This comprehensive guide provides valuable insights into exercise routines, nutrition plans, and mental wellness strategies. Whether you're just starting your fitness journey or looking to enhance your current routine, this book offers practical advice and expert tips to help you achieve your health goals.",
                    Author = "Harcourt Publishing",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    RatingValue = 4, 
                    ISBN = "9789876543210",
                    DatePublished = DateTime.Parse("2022-05-15"),
                    NumOfPages = 320,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "F4B7E79D-9FDE-4EE2-82DD-0B788C593DCB",
                    BookId = "29",
                    Title = "Stainless Skin: Re-invent Your Skin",
                    Description = "Uncover the secrets to achieving radiant and healthy skin with 'Stainless Skin: Re-invent Your Skin.' This book delves into the science of skincare, providing readers with practical advice on skincare routines, effective treatments, and lifestyle changes that contribute to vibrant and youthful skin. From tackling common skin concerns to embracing a holistic approach to beauty, this guide is your companion on the journey to achieving your best skin ever.",
                    Author = "Skincare Experts",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9780123475789", 
                    DatePublished = DateTime.Parse("2023-07-20"),
                    NumOfPages = 240,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "A5B6D2E1-FA98-4C43-AE1F-5F0A61BC7892",
                    BookId = "30",
                    Title = "Making Aromatherapy Creams and Lotions",
                    Description = "Discover the art of creating luxurious and therapeutic aromatherapy creams and lotions with 'Making Aromatherapy Creams and Lotions.' This comprehensive guide provides step-by-step instructions for crafting your own skincare products using natural ingredients and essential oils. From soothing body lotions to revitalizing facial creams, this book empowers you to personalize your skincare routine while harnessing the benefits of aromatherapy. Whether you're a beginner or an experienced crafter, this book is your gateway to healthy and fragrant self-care.",
                    Author = "Dr. Donna Maria",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9789876543210",
                    DatePublished = DateTime.Parse("2023-08-15"),
                    NumOfPages = 160,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "E2A3F4D5-B6C7-A8B9-C0D1-E2F3A4B5C6D7",
                    BookId = "31",
                    Title = "Energetic Skincare",
                    Description = "Discover the transformative power of energetic skincare with 'Energetic Skincare' by Jon Cannex. This groundbreaking book explores the fusion of modern skincare practices with energy healing techniques, offering a holistic approach to radiant and healthy skin. Learn how to align your inner energy with your skincare routine, select products that resonate with your energy, and create a harmonious balance between your physical and energetic well-being. With practical insights and mindful practices, this book is a must-read for those seeking a deeper connection between self-care and energetic vitality.",
                    Author = "Jon Cannex",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781234567899", 
                    DatePublished = DateTime.Parse("2023-09-01"),
                    NumOfPages = 200,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "F1E2D3C4-B5A6-7C8D-9E0F-A1B2C3D4E5F6",
                    BookId = "32",
                    Title = "The Three Most Coveted Beauty Looks",
                    Description = "Unlock the secrets of timeless beauty with 'The Three Most Coveted Beauty Looks'. In this comprehensive guide, you'll learn how to master the art of three iconic beauty styles that have captured the hearts of generations. From the classic Hollywood glamour to the minimalist natural beauty, and the bold and daring avant-garde, this book covers it all. Explore step-by-step tutorials, expert tips, and behind-the-scenes insights from top makeup artists, helping you recreate these coveted looks with confidence. Elevate your beauty game and embrace your unique style with the guidance of this inspiring beauty compendium.",
                    Author = "Author Name Here",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9789876543210", 
                    DatePublished = DateTime.Parse("2023-08-15"),
                    NumOfPages = 150,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "A1B2C3D4-E5F6-G7H8-I9J0-K1L2M3N4O5P6",
                   BookId = "33",
                   Title = "Lotion Making for Beginners",
                   Description = "Discover the art and science of creating luxurious lotions with 'Lotion Making for Beginners'. This comprehensive guide is tailored for those new to the world of skincare and crafting. From selecting the finest ingredients to mastering the emulsification process, this book covers it all. Learn about various types of lotions, from light and hydrating to rich and indulgent, and explore a range of botanical extracts, essential oils, and natural additives that can enhance the nourishing properties of your creations. With step-by-step instructions and practical tips, you'll embark on a journey to create beautiful and skin-loving lotions that pamper and delight.",
                   Author = "Madison Frank",
                   AvailableCopies = 15,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4,
                   ISBN = "9781234567890",
                   DatePublished = DateTime.Parse("2023-09-01"),
                   NumOfPages = 120,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "B7A6D5C4-E3F2-G1H0-I9J8-K7L6M5N4O3P2",
                    BookId = "34",
                    Title = "10-Minute Makeup",
                    Description = "Unlock the secrets to achieving a flawless and polished look in just 10 minutes with '10-Minute Makeup'. This book is your ultimate guide to quick and effective makeup routines that fit into your busy lifestyle. Whether you're a beginner or an experienced makeup enthusiast, you'll find a variety of tips, techniques, and step-by-step instructions to enhance your natural beauty in no time. From a fresh and natural everyday look to a glamorous evening transformation, this book covers it all. Discover product recommendations, time-saving tricks, and personalized makeup strategies that suit your skin type, face shape, and style preferences. Get ready to conquer your makeup routine with confidence and radiance.",
                    Author = "Makeup Artist Name",
                    AvailableCopies = 20,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9789876543210", 
                    DatePublished = DateTime.Parse("2023-10-15"),
                    NumOfPages = 160,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "A1B2C3D4-E5F6-G7H8-I9J0-K1L2M3N4O5P6",
                    BookId = "35",
                    Title = "HTML, XHTML and CSS For Dummies",
                    Description = "Master the fundamentals of web development with 'HTML, XHTML and CSS For Dummies'. Whether you're a beginner looking to build your first website or an experienced developer seeking to refresh your skills, this comprehensive guide has got you covered. Dive into the world of HTML and learn how to structure content, create links, and work with multimedia elements. Explore the power of XHTML for modern web pages and harness the styling capabilities of CSS to design attractive and responsive layouts. With practical examples and step-by-step instructions, you'll gain the knowledge you need to craft engaging and visually appealing web experiences. Get ready to embark on your journey into web development with this user-friendly guide.",
                    Author = "O'Reilly Media",
                    AvailableCopies = 15,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781118008167", 
                    DatePublished = DateTime.Parse("2022-05-20"),
                    NumOfPages = 400,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


               new Book
               {
                   Id = "BBA5D8A3-1D35-42D4-8C90-724F92497D9E",
                   BookId = "36",
                   Title = "Head First Python",
                   Description = "Unlock the power of Python programming with 'Head First Python'. This engaging and interactive guide takes a unique approach to teaching programming concepts by using visual puzzles, humor, and real-world examples. Dive into the world of Python and learn how to write clean, efficient, and effective code. Explore fundamental concepts, such as data types, loops, functions, and object-oriented programming, while building practical projects that range from simple games to web applications. With its hands-on exercises and playful approach, 'Head First Python' makes learning to program both educational and enjoyable.",
                   Author = "O'Reilly Media",
                   AvailableCopies = 15,
                   GenreId = "GenreIdHere",
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9781491919538",
                   DatePublished = new DateTime(2022, 6, 20),
                   NumOfPages = 450,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


               new Book
               {
                   Id = "5DDB13A4-35D0-47E6-9F97-5FD27CC0CE62",
                   BookId = "37",
                   Title = "Head First Web Design",
                   Description = "Learn the art of designing engaging and user-friendly websites with 'Head First Web Design'. This interactive guide takes you on a journey through the principles of effective web design, from understanding user needs and creating wireframes to implementing responsive layouts and optimizing performance. Through visual explanations, real-world examples, and hands-on exercises, you'll gain a deep understanding of design concepts, typography, color theory, and more. Discover the best practices for creating visually appealing and functional websites that provide a seamless user experience.",
                   Author = "O'Reilly Media",
                   AvailableCopies = 10,
                   GenreId = "GenreIdHere", 
                   Language = "English",
                   RatingValue = 4, 
                   ISBN = "9781491919514",
                   DatePublished = new DateTime(2022, 8, 15),
                   NumOfPages = 320,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               },


                new Book
                {
                    Id = "A9F5C8D2-7D15-4C35-BE8A-73C7A62E9A57",
                    BookId = "38",
                    Title = "Head First PHP & MySQL",
                    Description = "Dive into the world of web development with 'Head First PHP & MySQL'. This book is designed to teach you the essentials of creating dynamic and interactive web applications using PHP and MySQL. Through hands-on examples and engaging exercises, you'll learn the basics of PHP scripting, database design, and SQL queries. Whether you're a beginner or an experienced programmer, this book offers a practical approach to building web applications that store, retrieve, and manipulate data. With its interactive format and real-world projects, you'll gain the skills needed to create powerful web solutions.",
                    Author = "O'Reilly Media",
                    AvailableCopies = 8,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9780596006303",
                    DatePublished = new DateTime(2021, 5, 10),
                    NumOfPages = 480,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "E1A3F8B0-10F6-4ECF-8D13-9F7E2A8D9E11",
                    BookId = "39",
                    Title = "110 Easy Skin Care Tips",
                    Description = "Discover 110 practical and easy-to-follow skin care tips to enhance your beauty routine. In '110 Easy Skin Care Tips,' author Nada Manly shares her expertise in achieving healthy and radiant skin. From natural remedies to product recommendations, this book covers a wide range of topics including cleansing, moisturizing, exfoliating, and more. Whether you're a skincare novice or a beauty enthusiast, these tips will help you achieve a glowing complexion and maintain your skin's health.",
                    Author = "Nada Manly",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781522828950",
                    DatePublished = new DateTime(2022, 8, 15),
                    NumOfPages = 128,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "E9B4D7C2-596F-4E2E-97F6-A08F19E6743F",
                    BookId = "40",
                    Title = "80 Natural Remedies and Home Beauty Tips",
                    Description = "Unlock the power of nature with '80 Natural Remedies and Home Beauty Tips.' Author Nada Manly guides you through a variety of natural remedies and beauty solutions that can be created using common ingredients found in your kitchen and garden. From soothing skin masks to herbal teas, this book offers practical tips to enhance your well-being and radiance. Discover the benefits of harnessing the natural world to achieve healthier skin, hair, and overall beauty.",
                    Author = "Sarah Lee",
                    AvailableCopies = 12,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781500175265",
                    DatePublished = new DateTime(2022, 3, 22),
                    NumOfPages = 144,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "C4A786E7-8FA1-4A1C-9E44-F5F6188821D8",
                    BookId = "41",
                    Title = "Home Made Beauty",
                    Description = "Discover the secrets of natural beauty with 'Home Made Beauty' by Josephine M. Silva. This comprehensive guide offers a collection of DIY beauty recipes and treatments using everyday ingredients found in your kitchen. From homemade masks to nourishing hair treatments, Silva provides step-by-step instructions for achieving radiant and healthy skin, hair, and nails. Whether you're a beauty enthusiast or new to the world of natural skincare, this book is your go-to resource for enhancing your natural beauty the homemade way.",
                    Author = "Josephine M. Silva",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere", 
                    Language = "English",
                    RatingValue = 4, 
                    ISBN = "9781580176768",
                    DatePublished = new DateTime(2022, 8, 15),
                    NumOfPages = 208,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "B3F9E2D4-6A49-431C-8A68-94D9F3175219",
                    BookId = "42",
                    Title = "How to Have Youthful, Healthy Skin Naturally",
                    Description = "Unlock the secrets to maintaining youthful and healthy skin the natural way with 'How to Have Youthful, Healthy Skin Naturally' by Sara Jo Poff. In this book, Poff shares valuable insights and holistic approaches to skincare that focus on nourishing your skin from the inside out. Learn about the power of natural ingredients, essential oils, and lifestyle choices that contribute to vibrant and glowing skin. Whether you're looking to address specific skin concerns or simply enhance your natural beauty, this book offers practical advice and actionable tips to achieve the radiant skin you desire.",
                    Author = "Sara Jo Poff",
                    AvailableCopies = 12,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9781937918741",
                    DatePublished = new DateTime(2023, 7, 20),
                    NumOfPages = 160,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "D8B15B09-1BB4-4A61-B9C0-0E46341F5F0F",
                    BookId = "43",
                    Title = "Lotion Making",
                    Description = "Discover the art and science of creating your own lotions with 'Lotion Making' by Laura Neel. This comprehensive guide takes you on a journey through the process of crafting luxurious and nourishing lotions using natural ingredients. Neel shares her expertise and recipes that cover a wide range of lotions, from soothing body lotions to hydrating facial creams. With step-by-step instructions and helpful tips, this book empowers you to create personalized skincare products that cater to your unique needs and preferences.",
                    Author = "Laura Neel",
                    AvailableCopies = 10,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9781680995730",
                    DatePublished = new DateTime(2022, 3, 15),
                    NumOfPages = 224,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },


                new Book
                {
                    Id = "B7B53F83-F422-4DF5-8E75-89A8771670D1",
                    BookId = "44",
                    Title = "The Galactic Odyssey",
                    Description = "Embark on an epic journey across the cosmos in 'The Galactic Odyssey.' In this gripping science fiction tale, humanity has reached the stars and encountered alien civilizations. Join Captain Alex Rivers and her crew as they navigate interstellar politics, cosmic mysteries, and thrilling space battles. As the fate of Earth hangs in the balance, the crew must uncover ancient secrets that could change the course of the universe. With breathtaking world-building and imaginative technology, this book explores the vastness of space and the human spirit's enduring quest for knowledge and adventure.",
                    Author = "A. R. Stellar",
                    AvailableCopies = 5,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9781524763541",
                    DatePublished = new DateTime(2023, 7, 25),
                    NumOfPages = 368,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },

                new Book
                {
                    Id = "FC17AEC6-E01C-493B-A803-1026939EA46D",
                    BookId = "45",
                    Title = "Love & Harmony: Building a Lasting Marriage",
                    Description = "Discover the keys to a thriving and enduring marriage in 'Love & Harmony: Building a Lasting Marriage.' Renowned relationship expert Dr. Emily Roberts shares practical insights and time-tested advice to help couples navigate the challenges and joys of married life. From effective communication strategies to nurturing emotional intimacy, this book offers a comprehensive guide to creating a strong foundation for a lifelong partnership. Drawing on real-life stories and expert research, Dr. Roberts empowers couples to cultivate a love that grows stronger with each passing year.",
                    Author = "Dr. Emily Roberts",
                    AvailableCopies = 3,
                    GenreId = "GenreIdHere",
                    Language = "English",
                    RatingValue = 4,
                    ISBN = "9781543687210",
                    DatePublished = new DateTime(2022, 3, 15),
                    NumOfPages = 288,
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
