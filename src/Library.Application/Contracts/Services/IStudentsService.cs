using Library.Application.Models;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();

        Task<StudentDto> GetStudentAsync(Guid studentId);

        Task<Student> AddStudentAsync(StudentDto student);

        Task<StudentDto> GetStudentIdWithNoTrackingAsync(Guid studentId);

        Task UpdateStudentAsync(StudentDto student);

        Task DeleteStudentAsync(StudentDto student);
    }
}
