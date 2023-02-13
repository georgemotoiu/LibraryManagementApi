using Library.Application.Models;
using Library.Application.Responses;
using LibraryManagement.Application.Models;
using System;
using System.Collections.Generic;

namespace Library.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsSummaryResponse : BaseResponse<string>
    {
        public IEnumerable<StudentSummaryDto> Students { get; set; }
    }
}
