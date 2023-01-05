using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Library.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }                           
        public Guid MajorId { get; set; }
        public Major Major { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
