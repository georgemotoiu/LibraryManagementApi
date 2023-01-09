using Library.Application.Models;
using Library.Application.Responses;

namespace LibraryManagement.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandResponse : BaseResponse<string>
    {
        public StudentDto Student { get; set; }
    }
}
