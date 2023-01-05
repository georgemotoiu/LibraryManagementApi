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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Major)
                   .WithMany(p => p.Students)
                   .HasForeignKey(d => d.MajorId);
        }
    }
}
