using Library.Application.Models;
using Library.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudentsByFirstName
{
    public class UpdateStudentsByFirstNameResponse : BaseResponse<string>
    {
        public List<StudentDto> Students { get; set; }
    }
}
