using Library.Application.Models;
using Library.Application.Responses;
using LibraryManagement.Application.Features.Students.Commands.UpdateStudentsByFirstName;
using MediatR;
using System;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentsByFirstNameCommand : IRequest<UpdateStudentsByFirstNameResponse>
    {
    }
}
