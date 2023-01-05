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
    public class MajorConfiguration : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder
                .HasMany(u => u.Students)
                .WithOne(r => r.Major);
        }
    }
}
