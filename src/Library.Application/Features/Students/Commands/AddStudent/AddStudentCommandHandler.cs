using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentCommandResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<AddStudentCommandHandler> _logger;

        public AddStudentCommandHandler(IStudentsService studentsService, ILogger<AddStudentCommandHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }
        public async Task<AddStudentCommandResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new AddStudentCommandResponse();
            try
            {
                var student = await _studentsService.AddStudent(request.Model);
                _logger.LogInformation($"Added student {student.Id} with name {student.FirstName} {student.LastName}.");

                createStudentCommandResponse.StudentId = student.Id;                
            }
            catch (Exception e)
            {
                _logger.LogError("Exception while adding student with id: {firstName} {lastName} -- {exMessage}", request.Model.FirstName,
                    request.Model.LastName,e.Message);
                return new AddStudentCommandResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return createStudentCommandResponse;
        }
    }
}
