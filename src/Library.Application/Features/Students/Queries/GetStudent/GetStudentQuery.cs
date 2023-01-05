using Library.Application.Features.Students.Queries.GetStudents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<GetStudentResponse>
    {
        public Guid Id { get; set; }
    }
}
