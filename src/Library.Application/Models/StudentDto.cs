using System;
using System.Collections.Generic;

namespace Library.Application.Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public Guid MajorId { get; set; }

        public List<BorrowDto> Borrows { get; set; }
    }
}
