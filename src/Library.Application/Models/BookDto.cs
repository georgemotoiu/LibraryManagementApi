using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public Guid AuthorId { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }        
    }
}
