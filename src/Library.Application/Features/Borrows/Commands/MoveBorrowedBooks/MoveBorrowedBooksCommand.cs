using Library.Application.Responses;
using MediatR;
using System;

namespace LibraryManagement.Application.Features.Borrows.Commands.MoveBorrowedBooks
{
    public class MoveBorrowedBooksCommand : IRequest<BaseResponse<string>>
    {
        public Guid FromStudentId { get; set; }

        public Guid ToStudentId { get; set; }

    }
}
