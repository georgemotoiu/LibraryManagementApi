using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TakenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BroughtDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookReturned = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("42e0d62a-fc03-488f-978e-be930a5d697f"), "Andrew", "Stellman" },
                    { new Guid("4c66b3ab-8bd1-4c5c-996c-9e1bf1fb339a"), "Judith", "Voet" },
                    { new Guid("4ede88ce-15ac-4088-8f6c-3bc48f7d8013"), "Seth", "Godin" },
                    { new Guid("51868b2b-4f23-439f-a1ed-fea89778e796"), "Victor", "Rodwell" },
                    { new Guid("9774a335-e152-49b2-ab16-06279376398a"), "Mark", "Price" },
                    { new Guid("a43c0be1-63e4-42ae-805b-2a786384ca17"), "Harry", "Beckwith" },
                    { new Guid("b01ca467-7462-40ba-aab0-f1c98a99d67d"), "John", "Skeet" },
                    { new Guid("d80dd1fc-bd30-4a24-98d3-1a4ff13caab0"), "Robert", "Cialdini" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Computer Science" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Marketing" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Biochemistry" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff"), "Finance" },
                    { new Guid("6a2472ea-ba0d-42a1-8d4b-81331eaf63c8"), "Science-Fiction" },
                    { new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df"), "Biology" },
                    { new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88"), "Computers" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PageCount", "Publisher", "Title", "TypeId" },
                values: new object[,]
                {
                    { new Guid("08a13fed-6218-4937-99c1-d5c9f7b154d7"), new Guid("d80dd1fc-bd30-4a24-98d3-1a4ff13caab0"), 300, "Revised", "The psychology of influence", new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff") },
                    { new Guid("247b0b41-840d-4fe9-951e-020c51b271be"), new Guid("9774a335-e152-49b2-ab16-06279376398a"), 820, "Packt Publishing", "C# 8.0 and .NET Core 3.0", new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88") },
                    { new Guid("24eaf8b5-2d43-4c35-bae7-8f60d73131fe"), new Guid("4ede88ce-15ac-4088-8f6c-3bc48f7d8013"), 555, "Pioneer", "Permission on Marketing", new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff") },
                    { new Guid("39a81177-c072-431e-bfbb-7602d4da6bfe"), new Guid("51868b2b-4f23-439f-a1ed-fea89778e796"), 258, "Lange Publishing", "Harper's Illustrated Biochemistry", new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df") },
                    { new Guid("5895ae97-b221-4cb1-9cd4-cc9a56437838"), new Guid("b01ca467-7462-40ba-aab0-f1c98a99d67d"), 528, "Manning", "C# in Depth", new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88") },
                    { new Guid("91f0eed7-4697-4acd-810b-7a9a0d12c08a"), new Guid("a43c0be1-63e4-42ae-805b-2a786384ca17"), 325, "O'Reily", "Selling the invisible", new Guid("687488fa-67ba-404c-8a07-a6e53fc7e4ff") },
                    { new Guid("b3d8e6bf-7da3-4172-88b7-7287d7d2ac18"), new Guid("42e0d62a-fc03-488f-978e-be930a5d697f"), 800, "O'Reily", "Head First C#", new Guid("9708eb63-c328-41bb-8779-f095bcfa6a88") },
                    { new Guid("f4ad89ab-1df4-49b6-ba35-96d1d51f49c9"), new Guid("4c66b3ab-8bd1-4c5c-996c-9e1bf1fb339a"), 998, "Wiley", "Fundamentals of Biochemistry", new Guid("6e543d2e-bf2b-4906-806d-a8478f26a3df") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "Email", "FirstName", "LastName", "MajorId" },
                values: new object[,]
                {
                    { new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"), new DateTime(1995, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "george@upb.com", "Motoiu", "George", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9") },
                    { new Guid("956e247f-617e-4d59-be6e-d2bbdc5b0e07"), new DateTime(2001, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "popalex@upb.com", "Alexandra", "Popescu", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6") },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@upb.com", "John", "Doe", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6") },
                    { new Guid("f6d05f10-4960-430e-aa8b-a42a9ac7749b"), new DateTime(1985, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "cr7@upb.com", "Cristiano", "Ronaldo", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa") }
                });

            migrationBuilder.InsertData(
                table: "Borrows",
                columns: new[] { "Id", "BookId", "BookReturned", "BroughtDate", "ReturnDate", "StudentId", "TakenDate" },
                values: new object[,]
                {
                    { new Guid("3e8e55fb-a411-4940-a0f4-e2ef38833955"), new Guid("39a81177-c072-431e-bfbb-7602d4da6bfe"), false, null, new DateTime(2023, 1, 17, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(521), new Guid("956e247f-617e-4d59-be6e-d2bbdc5b0e07"), new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(520) },
                    { new Guid("4e834717-2318-4cfc-8358-a58e97bf9a36"), new Guid("5895ae97-b221-4cb1-9cd4-cc9a56437838"), true, new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(503), new DateTime(2023, 1, 9, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(500), new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"), new DateTime(2022, 12, 26, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(463) },
                    { new Guid("adab2d00-4cdf-44c9-bf9b-28932e40f1b5"), new Guid("08a13fed-6218-4937-99c1-d5c9f7b154d7"), true, new DateTime(2023, 1, 5, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(529), new DateTime(2023, 1, 17, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(527), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(526) },
                    { new Guid("c0019f2a-81cc-4244-9d18-8315b2e41b1a"), new Guid("91f0eed7-4697-4acd-810b-7a9a0d12c08a"), true, new DateTime(2023, 1, 3, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(515), new DateTime(2023, 1, 9, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(513), new Guid("72ef5de9-0c12-4f5b-a4e2-54a3866314f1"), new DateTime(2022, 12, 26, 16, 54, 33, 36, DateTimeKind.Local).AddTicks(511) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TypeId",
                table: "Books",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_StudentId",
                table: "Borrows",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MajorId",
                table: "Students",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
