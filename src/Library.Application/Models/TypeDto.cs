using System;
using System.Collections.Generic;

namespace Library.Application.Models
{
    public class TypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
