using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, GetStudentResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<GetStudentQueryHandler> _logger;

        public GetStudentQueryHandler(IStudentsService studentsService, ILogger<GetStudentQueryHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }
        public async Task<GetStudentResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {                
                var student = await _studentsService.GetStudentAsync(request.Id);

                if (student == null)
                {
                    return new GetStudentResponse
                    {                        
                        Success = false,
                        Message = $"Student with id {request.Id} doesn't exist!"
                    };
                }

                return new GetStudentResponse
                {
                    Student = student,
                    Success = true
                };
            }
            catch (Exception e)
            {
                var message = $"Failed to retrieve student with id: {request.Id} -- {e.Message}";
                _logger.LogError(message);
                return new GetStudentResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
