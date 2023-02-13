using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<GetStudentsQueryHandler> _logger;

        public GetStudentsQueryHandler(IStudentsService studentsService, ILogger<GetStudentsQueryHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public async Task<GetStudentsResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Retrieving all students.");
                var students = await _studentsService.GetStudentsAsync();
                var getAllStudentsResponse = new GetStudentsResponse
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

                return new GetStudentsResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
