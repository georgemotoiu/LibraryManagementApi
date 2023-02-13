using AutoMapper;
using Library.Application.Models;
using Library.Domain.Entities;
using Library.Persistance;
using Library.Persistance.Repositories;
using LibraryManagement.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistance.Repositories
{
    public class StudentRepository : BaseRepository<Student, StudentDto>, IStudentRepository
    {
        public StudentRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }        

        public async Task<List<StudentDto>> GetStudentsThatBorrowedBooksAsync()
        {
            var students = await _dbSet.Where(s => s.Borrows.Any()).ToListAsync();            
            return _mapper.Map<List<Student>, List<StudentDto>>(students);
        }

        public async Task<List<StudentDto>> GetStudentsWithFirstNameAsync(string firstName)
        {
            var students = await _dbSet.Where(s => s.FirstName.Equals(firstName)).ToListAsync();
            return _mapper.Map<List<Student>, List<StudentDto>>(students);
        }
    }
}
