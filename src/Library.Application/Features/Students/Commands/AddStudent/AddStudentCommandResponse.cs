using Library.Application.Models;
using Library.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandResponse : BaseResponse<string>
    {
        public Guid StudentId { get; set; }
    }
}
