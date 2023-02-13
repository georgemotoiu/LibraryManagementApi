using AutoMapper;
using Library.Application.Models;
using Library.Domain.Entities;
using Library.Persistance;
using Library.Persistance.Repositories;
using LibraryManagement.Application.Contracts.Repositories;
using LibraryManagement.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistance.Repositories
{
    public class StudentRepository : BaseRepository<Student, StudentDto>, IStudentRepository
    {
        public StudentRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<StudentDto>> UpdateStudentsByFirstNameAsync()
        {
            var students = await _dbSet.Where(s => s.FirstName.StartsWith("A") ||
                                  s.FirstName.StartsWith("I") ||
                                  s.FirstName.StartsWith("G"))
                      .ToListAsync();

            foreach (var student in students)
            {
                switch (student.FirstName.Substring(0, 1).ToLowerInvariant())
                {
                    case "a":
                        student.LastName += "x";
                        break;
                    case "i":
                        student.LastName += "xx";
                        break;
                    case "g":
                        student.LastName += "xxx";
                        break;
                }
            }

            _context.Students.UpdateRange(students);
            _context.SaveChanges();

            return _mapper.Map<List<Student>, List<StudentDto>>(students);
        }

        public async Task<List<StudentSummaryDto>> GetStudentsSummaryAsync()
        {
            var students = _dbSet.Where(s => s.Borrows.Count() >= 3)
                .Select(s => new StudentSummaryDto
                {
                    Name = s.LastName,
                    NumBooksBorrowed = s.Borrows.Count(),
                    Status = s.Borrows.Count() > 10 ? "Fraud" : "GoodReader"
                });

            return await students.ToListAsync();

        }

        public async Task<List<StudentDto>> GetStudentsThatBorrowedBooksAsync()
        {
            var students = await _dbSet.Where(s => s.Borrows.Any()).ToListAsync();
            return _mapper.Map<List<Student>, List<StudentDto>>(students);
        }
    }
}
