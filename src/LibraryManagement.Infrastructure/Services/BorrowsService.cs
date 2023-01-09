using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using LibraryManagement.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Services
{
    public class BorrowsService : IBorrowsService
    {
        /// <summary>
        ///     The <see cref="IBaseRepository" /> to use.
        /// </summary>
        private readonly IBaseRepository<Borrow, BorrowDto> _borrowRepository;

        public BorrowsService(IBaseRepository<Borrow, BorrowDto> borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public async Task<Borrow> AddBorrowAsync(BorrowDto model)
        {
            var result = await _borrowRepository.AddAsync(model);

            return result;
        }
    }
}
