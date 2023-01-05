using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Major
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
