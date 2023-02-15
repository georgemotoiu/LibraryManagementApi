using AutoMapper;
using Library.Application.Models;
using Library.Domain.Entities;
using Library.Persistance;
using Library.Persistance.Repositories;
using LibraryManagement.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistance.Repositories
{
    public class AuthorRepository : BaseRepository<Author, AuthorDto>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<AuthorDto>> GetMostBorrowedAuthorsAsync()
        {

            var topAuthors = await _context.Authors.OrderByDescending(a => _context.Borrows
                    .Where(b => a.Books.Any(book => book.Id == b.BookId))
                    .Count())
                    .Take(3)
                    .ToListAsync();        

            return _mapper.Map<List<Author>, List<AuthorDto>>(topAuthors);

        }
    }
}
