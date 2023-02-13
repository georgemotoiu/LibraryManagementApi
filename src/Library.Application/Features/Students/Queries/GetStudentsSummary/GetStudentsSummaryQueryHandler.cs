using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsSummaryQueryHandler : IRequestHandler<GetStudentsSummaryQuery, GetStudentsSummaryResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<GetStudentsSummaryQueryHandler> _logger;

        public GetStudentsSummaryQueryHandler(IStudentsService studentsService, ILogger<GetStudentsSummaryQueryHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public async Task<GetStudentsSummaryResponse> Handle(GetStudentsSummaryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Retrieving student summary.");
                var students = await _studentsService.GetStudentsSummaryAsync();
                var getAllStudentsResponse = new GetStudentsSummaryResponse
                {
                    Students = students,
                    Success = true
                };

                return getAllStudentsResponse;
            }
            catch (Exception e)
            {
                var message = $"Failed to retrieve students -- {e.Message}";
                _logger.LogError(message);

                return new GetStudentsSummaryResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
