using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Models
{
    public class StudentSummaryDto
    {
        public string Name { get; set; }
        public int NumBooksBorrowed { get; set; }
        public string Status { get; set; }
    }
}
