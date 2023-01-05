using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System;

namespace Library.Domain.Entities
{
    public class Type
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
