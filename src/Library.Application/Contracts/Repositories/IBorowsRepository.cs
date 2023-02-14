using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LibraryManagement.Application.Contracts.Repositories
{
    public interface IBorowsRepository : IBaseRepository<Borrow, BorrowDto>
    {
        Task MoveBorrowedBooksAsync(List<Borrow> borrows, Guid toStudentId);

        Task<List<Borrow>> GetBorrowedBooksFromStudent(Guid fromStudentId);
    }
}
