using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Application.Responses;
using Library.Domain.Entities;
using LibraryManagement.Application.Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Borrows.Commands.MoveBorrowedBooks
{
    public class MoveBorrowedBooksCommandHandler : IRequestHandler<MoveBorrowedBooksCommand, BaseResponse<string>>
    {
        private readonly ILogger<MoveBorrowedBooksCommandHandler> _logger;
        private readonly IBaseRepository<Student, StudentDto> _studentsRepository;
        private readonly IBorowsRepository _borrowsRepository;

        public MoveBorrowedBooksCommandHandler(IBaseRepository<Student, StudentDto> studentsRepository, ILogger<MoveBorrowedBooksCommandHandler> logger)
        {
            _studentsRepository = studentsRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<string>> Handle(MoveBorrowedBooksCommand request, CancellationToken cancellationToken)
        {
            var successMessage = $"Transfered books from student: {request.FromStudentId} to student {request.ToStudentId}";
            var response = new BaseResponse<string>("", true);

            try
            {
                var fromStudent = await _studentsRepository.GetByIdWithNoTrackingAsync(request.FromStudentId);
                var toStudent = await _studentsRepository.GetByIdWithNoTrackingAsync(request.ToStudentId);

                if (fromStudent == null || toStudent == null)
                {
                    response.Success = false;
                    response.Message = $"From student with id: {request.FromStudentId} doesn't exist!";
                    _logger.LogError(response.Message);

                    return response;
                }

                var borrowedBooks = await _borrowsRepository.GetBorrowedBooksFromStudent(request.FromStudentId);

                if (borrowedBooks.Any())
                {
                    response.Success = false;
                    response.Message = $"The student with id {request.FromStudentId} has no borrowed books to move.";
                    _logger.LogError(response.Message);

                    return response;
                }

                await _borrowsRepository.MoveBorrowedBooksAsync(borrowedBooks, request.ToStudentId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Failed to move books from : {request.FromStudentId} - {ex.Message}";
                _logger.LogError(response.Message);

                return response;
            }

            _logger.LogInformation(successMessage);

            return response;
        }
    }
}
