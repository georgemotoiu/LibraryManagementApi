using Library.Application.Models;
using Library.Application.Responses;
using LibraryManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Queries.GetStudentsWithLeastBooks
{
    public class GetStudentsWithLeastBooksResponse : BaseResponse<string>
    {
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
