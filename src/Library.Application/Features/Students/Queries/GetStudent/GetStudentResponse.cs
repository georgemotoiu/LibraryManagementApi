using Library.Application.Models;
using Library.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentResponse : BaseResponse<string>
    {
        public StudentDto Student { get; set; }
    }

}
