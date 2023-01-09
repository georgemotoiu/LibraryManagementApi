using Library.Application.Models;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Services
{
    public interface IBorrowsService
    {
        Task<Borrow> AddBorrowAsync(BorrowDto borrow);
    }
}
