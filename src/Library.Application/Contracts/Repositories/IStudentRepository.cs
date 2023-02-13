using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student, StudentDto>
    {
        Task<List<StudentDto>> GetStudentsThatBorrowedBooksAsync();

        Task<List<StudentDto>> UpdateStudentsByFirstNameAsync();
    }
}
