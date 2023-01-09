using Library.Application.Models;
using Library.Application.Responses;
using MediatR;
using System;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<BaseResponse<string>>
    {
        public Guid StudentId { get; set; }

        public StudentDto Model { get; set; }
    }
}
