using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Identity.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7fc7a12a-8653-417a-a618-c692554e5e2a", 0, "024282ff-6681-455e-8eda-ca6cd5d185cb", "motoiugeorge@upb.com", true, "George", "Motoiu", false, null, null, null, null, null, false, "43b7709d-4a8b-4dec-8a3b-8ce29eebe531", false, "motoiugeorge" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fc7a12a-8653-417a-a618-c692554e5e2a");
        }
    }
}
