using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Title).IsRequired();

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId);

            builder.HasOne(d => d.Type)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.TypeId);
        }
    }
}
