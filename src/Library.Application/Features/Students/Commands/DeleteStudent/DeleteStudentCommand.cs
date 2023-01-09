using Library.Application.Responses;
using MediatR;
using System;

namespace LibraryManagement.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<BaseResponse<string>>
    {
        public Guid StudentId { get; set; } 
    }
}
