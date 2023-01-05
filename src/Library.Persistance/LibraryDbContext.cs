using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Type = Library.Domain.Entities.Type;

namespace Library.Persistance
{
    /// <summary>
    ///     A <see cref="DbContext" /> extesion for the library api.
    /// </summary>
    public class LibraryDbContext : DbContext
    {

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// The <see cref="DbContext.OnModelCreating(ModelBuilder)"/> event handler.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> to use.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedData(modelBuilder);
        }

        /// <summary>
        /// Initializes the test data.
        /// </summary>
        public void SeedData(ModelBuilder modelBuilder)
        {
            var computerScienceMajorGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var marketingMajorGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var biochemistryMajorGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    FirstName = "John",
                    LastName = "Doe",
                    Birthdate = new DateTime(1999, 01, 01),
                    Email = "johndoe@upb.com",
                    MajorId = computerScienceMajorGuid,
                    Borrows = new List<Borrow>()
                },
                new Student
                {
                    Id = Guid.Parse("{72EF5DE9-0C12-4F5B-A4E2-54A3866314F1}"),
                    FirstName = "Motoiu",
                    LastName = "George",
                    Birthdate = new DateTime(1995, 09, 11),
                    Email = "george@upb.com",
                    MajorId = biochemistryMajorGuid,
                    Borrows = new List<Borrow>()
                },
                new Student
                {
                    Id = Guid.Parse("{F6D05F10-4960-430E-AA8B-A42A9AC7749B}"),
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Birthdate = new DateTime(1985, 02, 08),
                    Email = "cr7@upb.com",
                    MajorId = marketingMajorGuid,
                    Borrows = new List<Borrow>()
                },
                new Student
                {
                    Id = Guid.Parse("{956E247F-617E-4D59-BE6E-D2BBDC5B0E07}"),
                    FirstName = "Alexandra",
                    LastName = "Popescu",
                    Birthdate = new DateTime(2001, 12, 15),
                    Email = "popalex@upb.com",
                    MajorId = computerScienceMajorGuid,
                    Borrows = new List<Borrow>()
                }
            );
            modelBuilder.Entity<Major>().HasData(
                new Major { Id = computerScienceMajorGuid, Name = "Computer Science" },
                new Major { Id = marketingMajorGuid, Name = "Marketing" },
                new Major { Id = biochemistryMajorGuid, Name = "Biochemistry" }
            );

            var andrewStellmanGuid = Guid.Parse("42E0D62A-FC03-488F-978E-BE930A5D697F");
            var markPriceGuid = Guid.Parse("9774A335-E152-49B2-AB16-06279376398A");
            var johnSkeetGuid = Guid.Parse("B01CA467-7462-40BA-AAB0-F1C98A99D67D");

            var harryBeckwithGuid = Guid.Parse("A43C0BE1-63E4-42AE-805B-2A786384CA17");
            var sethGodinGuid = Guid.Parse("4EDE88CE-15AC-4088-8F6C-3BC48F7D8013");
            var robertCialdiniGuid = Guid.Parse("D80DD1FC-BD30-4A24-98D3-1A4FF13CAAB0");

            var victorRodwellGuid = Guid.Parse("51868B2B-4F23-439F-A1ED-FEA89778E796");
            var judithVoetGuid = Guid.Parse("4C66B3AB-8BD1-4C5C-996C-9E1BF1FB339A");



            modelBuilder.Entity<Author>().HasData(
                   new Author { Id = andrewStellmanGuid, FirstName = "Andrew", LastName = "Stellman" },
                   new Author { Id = markPriceGuid, FirstName = "Mark", LastName = "Price" },
                   new Author { Id = johnSkeetGuid, FirstName = "John", LastName = "Skeet" },
                   new Author { Id = harryBeckwithGuid, FirstName = "Harry", LastName = "Beckwith" },
                   new Author { Id = sethGodinGuid, FirstName = "Seth", LastName = "Godin" },
                   new Author { Id = robertCialdiniGuid, FirstName = "Robert", LastName = "Cialdini" },
                   new Author { Id = victorRodwellGuid, FirstName = "Victor", LastName = "Rodwell" },
                   new Author { Id = judithVoetGuid, FirstName = "Judith", LastName = "Voet" }
             );

            var computersTypeGuid = Guid.Parse("9708EB63-C328-41BB-8779-F095BCFA6A88");
            var biochemistryTypeGuid = Guid.Parse("6E543D2E-BF2B-4906-806D-A8478F26A3DF");
            var financeTypeGuid = Guid.Parse("687488FA-67BA-404C-8A07-A6E53FC7E4FF");
            var scienceFictionTypeGuid = Guid.Parse("6A2472EA-BA0D-42A1-8D4B-81331EAF63C8");

            modelBuilder.Entity<Type>().HasData(
                  new Type { Id = computersTypeGuid, Name = "Computers" },
                  new Type { Id = biochemistryTypeGuid, Name = "Biology" },
                  new Type { Id = financeTypeGuid, Name = "Finance" },
                  new Type { Id = scienceFictionTypeGuid, Name = "Science-Fiction" }

             );

            modelBuilder.Entity<Book>().HasData(
                  new Book
                  {
                      Id = Guid.Parse("B3D8E6BF-7DA3-4172-88B7-7287D7D2AC18"),
                      Title = "Head First C#",
                      PageCount = 800,
                      Publisher = "O'Reily",
                      AuthorId = andrewStellmanGuid,
                      TypeId = computersTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("247B0B41-840D-4FE9-951E-020C51B271BE"),
                      Title = "C# 8.0 and .NET Core 3.0",
                      PageCount = 820,
                      Publisher = "Packt Publishing",
                      AuthorId = markPriceGuid,
                      TypeId = computersTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("5895AE97-B221-4CB1-9CD4-CC9A56437838"),
                      Title = "C# in Depth",
                      PageCount = 528,
                      Publisher = "Manning",
                      AuthorId = johnSkeetGuid,
                      TypeId = computersTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("39A81177-C072-431E-BFBB-7602D4DA6BFE"),
                      Title = "Harper's Illustrated Biochemistry",
                      PageCount = 258,
                      Publisher = "Lange Publishing",
                      AuthorId = victorRodwellGuid,
                      TypeId = biochemistryTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("F4AD89AB-1DF4-49B6-BA35-96D1D51F49C9"),
                      Title = "Fundamentals of Biochemistry",
                      PageCount = 998,
                      Publisher = "Wiley",
                      AuthorId = judithVoetGuid,
                      TypeId = biochemistryTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("24EAF8B5-2D43-4C35-BAE7-8F60D73131FE"),
                      Title = "Permission on Marketing",
                      PageCount = 555,
                      Publisher = "Pioneer",
                      AuthorId = sethGodinGuid,
                      TypeId = financeTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("91F0EED7-4697-4ACD-810B-7A9A0D12C08A"),
                      Title = "Selling the invisible",
                      PageCount = 325,
                      Publisher = "O'Reily",
                      AuthorId = harryBeckwithGuid,
                      TypeId = financeTypeGuid,
                      Borrows = new List<Borrow>()
                  },
                  new Book
                  {
                      Id = Guid.Parse("08A13FED-6218-4937-99C1-D5C9F7B154D7"),
                      Title = "The psychology of influence",
                      PageCount = 300,
                      Publisher = "Revised",
                      AuthorId = robertCialdiniGuid,
                      TypeId = financeTypeGuid,
                      Borrows = new List<Borrow>()
                  }
             );

            modelBuilder.Entity<Borrow>().HasData(
                  new Borrow
                  {
                      Id = Guid.Parse("4E834717-2318-4CFC-8358-A58E97BF9A36"),
                      TakenDate = DateTime.Now.AddDays(-10),
                      ReturnDate = DateTime.Now.AddDays(-10).AddDays(14),
                      BroughtDate = DateTime.Now.AddDays(-2),
                      BookReturned = true,
                      StudentId = Guid.Parse("{72EF5DE9-0C12-4F5B-A4E2-54A3866314F1}"),
                      BookId = Guid.Parse("5895AE97-B221-4CB1-9CD4-CC9A56437838")
                  },
                  new Borrow
                  {
                      Id = Guid.Parse("C0019F2A-81CC-4244-9D18-8315B2E41B1A"),
                      TakenDate = DateTime.Now.AddDays(-10),
                      ReturnDate = DateTime.Now.AddDays(-10).AddDays(14),
                      BroughtDate = DateTime.Now.AddDays(-2),
                      BookReturned = true,
                      StudentId = Guid.Parse("{72EF5DE9-0C12-4F5B-A4E2-54A3866314F1}"),
                      BookId = Guid.Parse("91F0EED7-4697-4ACD-810B-7A9A0D12C08A")
                  },
                  new Borrow
                  {
                      Id = Guid.Parse("3E8E55FB-A411-4940-A0F4-E2EF38833955"),
                      TakenDate = DateTime.Now.AddDays(-2),
                      ReturnDate = DateTime.Now.AddDays(-2).AddDays(14),                      
                      BookReturned = false,
                      StudentId = Guid.Parse("{956E247F-617E-4D59-BE6E-D2BBDC5B0E07}"),
                      BookId = Guid.Parse("39A81177-C072-431E-BFBB-7602D4DA6BFE")
                  },
                  new Borrow
                  {
                      Id = Guid.Parse("ADAB2D00-4CDF-44C9-BF9B-28932E40F1B5"),
                      TakenDate = DateTime.Now.AddDays(-2),
                      ReturnDate = DateTime.Now.AddDays(-2).AddDays(14),
                      BroughtDate = DateTime.Now,
                      BookReturned = true,
                      StudentId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                      BookId = Guid.Parse("08A13FED-6218-4937-99C1-D5C9F7B154D7")
                  }                  
             );

        }
    }
}
