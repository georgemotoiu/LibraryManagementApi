using Library.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommand : IRequest<AddStudentCommandResponse>
    {
        public StudentDto Model { get; set; }
    }
}
