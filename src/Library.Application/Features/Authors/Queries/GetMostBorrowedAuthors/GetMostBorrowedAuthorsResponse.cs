using Library.Application.Models;
using Library.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Queries.GetMostBorrowedAuthors
{
    public class GetMostBorrowedAuthorsResponse : BaseResponse<string>
    {
        public IEnumerable<AuthorDto> Authors { get; set; }
    }
}
