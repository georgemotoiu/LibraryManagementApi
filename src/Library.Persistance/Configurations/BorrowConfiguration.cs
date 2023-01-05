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
    public class BorrowConfiguration : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Book)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.BookId);

            builder.HasOne(d => d.Student)
                .WithMany(p => p.Borrows)
                .HasForeignKey(d => d.StudentId);                
        }
    }
}
