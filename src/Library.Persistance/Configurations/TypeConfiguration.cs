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
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder
                .HasMany(u => u.Books)
                .WithOne(r => r.Type);
        }
    }
}
