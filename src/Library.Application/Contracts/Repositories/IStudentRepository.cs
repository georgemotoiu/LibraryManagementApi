using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using LibraryManagement.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student, StudentDto>
    {
        Task<List<StudentDto>> GetStudentsThatBorrowedBooksAsync();

        Task<List<StudentDto>> GetStudentsWithLeastBorrowedBooksAsync();

        Task<List<StudentDto>> UpdateStudentsByFirstNameAsync();

        Task<List<StudentSummaryDto>> GetStudentsSummaryAsync();
    }
}
