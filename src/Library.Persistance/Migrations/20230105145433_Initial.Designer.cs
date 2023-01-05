﻿// <auto-generated />
using System;
using Library.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Persistance.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20230105145433_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42e0d62a-fc03-488f-978e-be930a5d697f"),
                            FirstName = "Andrew",
                            LastName = "Stellman"
                        },
                        new
                        {
                            Id = new Guid("9774a335-e152-49b2-ab16-06279376398a"),
                            FirstName = "Mark",
                            LastName = "Price"
                        },
                        new
                        {
                            Id = new Guid("b01ca467-7462-40ba-aab0-f1c98a99d67d"),
                            FirstName = "John",
                            LastName = "Skeet"
                        },
                        new
                        {
                            Id = new Guid("a43c0be1-63e4-42ae-805b-2a786384ca17"),
                            FirstName = "Harry",
                            LastName = "Beckwith"
                        },
                        new
                        {
                            Id = new Guid("4ede88ce-15ac-4088-8f6c-3bc48f7d8013"),
                            FirstName = "Seth",
                            LastName = "Godin"
                        },
                        new
                        {
                            Id = new Guid("d80dd1fc-bd30-4a24-98d3-1a4ff13caab0"),
                            FirstName = "Robert",
                            LastName = "Cialdini"
                        },
                        new
                        {
                            Id = new Guid("51868b2b-4f23-439f-a1ed-fea89778e796"),
                            FirstName = "Victor",
                            LastName = "Rodwell"
                        },
                        new
                        {
                            Id = new Guid("4c66b3ab-8bd1-4c5c-996c-9e1bf1fb339a"),
                            FirstName = "Judith",
                            LastName = "Voet"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TypeId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3d8e6bf-7da3-4172-88b7-7287d7d2ac18"),
                            AuthorId = new Guid("42e0d62a-fc03-488f-978e-be930a5d697f"),
                            PageCount = 800,
                            Publisher = "O'Reily",
                            Title = "Head First C#",
                            TypeId = new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88")
                        },
                        new
                        {
                            Id = new Guid("247b0b41-840d-4fe9-951e-020c51b271be"),
                            AuthorId = new Guid("9774a335-e152-49b2-ab16-06279376398a"),
                            PageCount = 820,
                            Publisher = "Packt Publishing",
                            Title = "C# 8.0 and .NET Core 3.0",
                            TypeId = new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88")
                        },
                        new
                        {
                            Id = new Guid("5895ae97-b221-4cb1-9cd4-cc9a56437838"),
                            AuthorId = new Guid("b01ca467-7462-40ba-aab0-f1c98a99d67d"),
                            PageCount = 528,
                            Publisher = "Manning",
                            Title = "C# in Depth",
                            TypeId = new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88")
                        },
                        new
                        {
                            Id = new Guid("39a81177-c072-431e-bfbb-7602d4da6bfe"),
                            AuthorId = new Guid("51868b2b-4f23-439f-a1ed-fea89778e796"),
                            PageCount = 258,
                            Publisher = "Lange Publishing",
                            Title = "Harper's Illustrated Biochemistry",
                            TypeId = new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df")
                        },
                        new
                        {
                            Id = new Guid("f4ad89ab-1df4-49b6-ba35-96d1d51f49c9"),
                            AuthorId = new Guid("4c66b3ab-8bd1-4c5c-996c-9e1bf1fb339a"),
                            PageCount = 998,
                            Publisher = "Wiley",
                            Title = "Fundamentals of Biochemistry",
                            TypeId = new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df")
                        },
                        new
                        {
                            Id = new Guid("24eaf8b5-2d43-4c35-bae7-8f60d73131fe"),
                            AuthorId = new Guid("4ede88ce-15ac-4088-8f6c-3bc48f7d8013"),
                            PageCount = 555,
                            Publisher = "Pioneer",
                            Title = "Permission on Marketing",
                            TypeId = new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff")
                        },
                        new
                        {
                            Id = new Guid("91f0eed7-4697-4acd-810b-7a9a0d12c08a"),
                            AuthorId = new Guid("a43c0be1-63e4-42ae-805b-2a786384ca17"),
                            PageCount = 325,
                            Publisher = "O'Reily",
                            Title = "Selling the invisible",
                            TypeId = new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff")
                        },
                        new
                        {
                            Id = new Guid("08a13fed-6218-4937-99c1-d5c9f7b154d7"),
                            AuthorId = new Guid("d80dd1fc-bd30-4a24-98d3-1a4ff13caab0"),
                            PageCount = 300,
                            Publisher = "Revised",
                            Title = "The psychology of influence",
                            TypeId = new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff")
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Borrow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BookReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BroughtDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TakenDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("Borrows");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e834717-2318-4cfc-8358-a58e97bf9a36"),
                            BookId = new Guid("5895ae97-b221-4cb1-9cd4-cc9a56437838"),
                            BookReturned = true,
                            BroughtDate = new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(503),
                            ReturnDate = new DateTime(2023, 1, 9, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(500),
                            StudentId = new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"),
                            TakenDate = new DateTime(2022, 12, 26, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(463)
                        },
                        new
                        {
                            Id = new Guid("c0019f2a-81cc-4244-9d18-8315b2e41b1a"),
                            BookId = new Guid("91f0eed7-4697-4acd-810b-7a9a0d12c08a"),
                            BookReturned = true,
                            BroughtDate = new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(515),
                            ReturnDate = new DateTime(2023, 1, 9, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(513),
                            StudentId = new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"),
                            TakenDate = new DateTime(2022, 12, 26, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(511)
                        },
                        new
                        {
                            Id = new Guid("3e8e55fb-a411-4940-a0f4-e2ef38833955"),
                            BookId = new Guid("39a81177-c072-431e-bfbb-7602d4da6bfe"),
                            BookReturned = false,
                            ReturnDate = new DateTime(2023, 1, 17, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(521),
                            StudentId = new Guid("956e247f-617e-4d59-be6e-d2bbdc5b0e07"),
                            TakenDate = new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(520)
                        },
                        new
                        {
                            Id = new Guid("adab2d00-4cdf-44c9-bf9b-28932e40f1b5"),
                            BookId = new Guid("08a13fed-6218-4937-99c1-d5c9f7b154d7"),
                            BookReturned = true,
                            BroughtDate = new DateTime(2023, 1, 5, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(529),
                            ReturnDate = new DateTime(2023, 1, 17, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(527),
                            StudentId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            TakenDate = new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(526)
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Majors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            Name = "Computer Science"
                        },
                        new
                        {
                            Id = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            Name = "Biochemistry"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Birthdate = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@upb.com",
                            FirstName = "John",
                            LastName = "Doe",
                            MajorId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6")
                        },
                        new
                        {
                            Id = new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"),
                            Birthdate = new DateTime(1995, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "george@upb.com",
                            FirstName = "Motoiu",
                            LastName = "George",
                            MajorId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            Id = new Guid("f6d05f10-4960-430e-aa8b-a42a9ac7749b"),
                            Birthdate = new DateTime(1985, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cr7@upb.com",
                            FirstName = "Cristiano",
                            LastName = "Ronaldo",
                            MajorId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa")
                        },
                        new
                        {
                            Id = new Guid("956e247f-617e-4d59-be6e-d2bbdc5b0e07"),
                            Birthdate = new DateTime(2001, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "popalex@upb.com",
                            FirstName = "Alexandra",
                            LastName = "Popescu",
                            MajorId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6")
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88"),
                            Name = "Computers"
                        },
                        new
                        {
                            Id = new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df"),
                            Name = "Biology"
                        },
                        new
                        {
                            Id = new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff"),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("6a2472ea-ba0d-42a1-8d4b-81331eaf63c8"),
                            Name = "Science-Fiction"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Library.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Type", "Type")
                        .WithMany("Books")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Library.Domain.Entities.Borrow", b =>
                {
                    b.HasOne("Library.Domain.Entities.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Student", "Student")
                        .WithMany("Borrows")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Library.Domain.Entities.Student", b =>
                {
                    b.HasOne("Library.Domain.Entities.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("Library.Domain.Entities.Major", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Library.Domain.Entities.Student", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("Library.Domain.Entities.Type", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
