using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public Guid AuthorId { get; set; }
        public Guid TypeId { get; set; }

        public Author Author { get; set; }
        public Type Type { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
