using System;
using System.Collections.Generic;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Domain.Entities
{
    public class Borrow
    {
        public Guid Id { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? BroughtDate { get; set; }
        public bool BookReturned { get; set; }
        public Guid StudentId { get; set; }
        public Guid BookId { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }
    }
}
