using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsResponse>
    {
        private readonly IBaseRepository<Student, StudentDto> _studentRepository;
        private readonly ILogger<GetStudentsQueryHandler> _logger;

        public GetStudentsQueryHandler(IBaseRepository<Student, StudentDto> studentRepository, ILogger<GetStudentsQueryHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<GetStudentsResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Retrieving all students.");
                var students = await _studentRepository.GetAllAsync();
                var getAllStudentsResponse = new GetStudentsResponse
                {
                    Students = students.ToList(),
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
