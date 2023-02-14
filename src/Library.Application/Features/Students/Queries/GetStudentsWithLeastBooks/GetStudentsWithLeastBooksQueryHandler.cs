
using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Queries.GetStudentsWithLeastBooks
{
    public class GetStudentsWithLeastBooksQueryHandler : IRequestHandler<GetStudentsWithLeastBooksQuery, GetStudentsWithLeastBooksResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<GetStudentsWithLeastBooksQueryHandler> _logger;

        public GetStudentsWithLeastBooksQueryHandler(IStudentsService studentsService, ILogger<GetStudentsWithLeastBooksQueryHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public async Task<GetStudentsWithLeastBooksResponse> Handle(GetStudentsWithLeastBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Retrieving lazy students.");
                var students = await _studentsService.GetStudentsWithLeastBorrowedBooksAsync();
                var response = new GetStudentsWithLeastBooksResponse
                {
                    Students = students,
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                var message = $"Failed to retrieve students -- {e.Message}";
                _logger.LogError(message);

                return new GetStudentsWithLeastBooksResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
