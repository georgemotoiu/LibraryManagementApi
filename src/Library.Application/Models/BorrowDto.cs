using System;

namespace Library.Application.Models
{
    public class BorrowDto
    {
        public Guid Id { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? BroughtDate { get; set; }
        public string BookName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public Guid StudentId { get; set; }
        public Guid BookId { get; set; }
    }
}
