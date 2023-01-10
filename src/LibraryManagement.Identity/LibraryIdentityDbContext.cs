using LibraryManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManagement.Identity
{
    public class LibraryIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryIdentityDbContext(DbContextOptions<LibraryIdentityDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// The <see cref="DbContext.OnModelCreating(ModelBuilder)"/> event handler.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> to use.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "George",
                LastName = "Motoiu",
                UserName = "motoiugeorge",
                Email = "motoiugeorge@upb.com",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            passwordHasher.HashPassword(applicationUser, "Test123!");

            builder.Entity<ApplicationUser>().HasData(applicationUser);
        }
    }
}
