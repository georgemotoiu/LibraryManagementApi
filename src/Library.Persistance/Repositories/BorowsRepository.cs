using AutoMapper;
using Library.Application.Models;
using Library.Domain.Entities;
using Library.Persistance;
using Library.Persistance.Repositories;
using LibraryManagement.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistance.Repositories
{
    public class BorowsRepository : BaseRepository<Borrow, BorrowDto>, IBorowsRepository
    {
        public BorowsRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<Borrow>> GetBorrowedBooksFromStudent(Guid fromStudentId)
        {
            return await _dbSet.Where(b => b.StudentId == fromStudentId && !b.BookReturned)
                                .ToListAsync();
        }

        public async Task MoveBorrowedBooksAsync(List<Borrow> borrows, Guid toStudentId)
        {
            borrows.ForEach(b => b.StudentId = toStudentId);

            await _context.SaveChangesAsync();
        }
    }
}
