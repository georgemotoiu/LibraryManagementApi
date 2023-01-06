using Library.Application.Models;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentDto>> GetStudents();

        Task<StudentDto> GetStudent(Guid studentId);

        Task<Student> AddStudent(StudentDto student);
    }
}
