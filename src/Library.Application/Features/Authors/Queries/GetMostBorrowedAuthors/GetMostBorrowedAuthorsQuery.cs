using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Queries.GetMostBorrowedAuthors
{
    public class GetMostBorrowedAuthorsQuery : IRequest<GetMostBorrowedAuthorsResponse>
    {
    }
}
