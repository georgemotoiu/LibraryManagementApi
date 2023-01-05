using Library.Application.Contracts.Repositories;
using Library.Application.Features.Students.Queries.GetStudents;
using Library.Application.Models;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, GetStudentResponse>
    {
        private readonly IBaseRepository<Student, StudentDto> _studentRepository;
        private readonly ILogger<GetStudentQueryHandler> _logger;

        public GetStudentQueryHandler(IBaseRepository<Student, StudentDto> studentRepository, ILogger<GetStudentQueryHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }
        public async Task<GetStudentResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentRepository.GetAsync(c => c.Id == request.Id, includeProperties: "Majors");
                var student = result.FirstOrDefault();

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
