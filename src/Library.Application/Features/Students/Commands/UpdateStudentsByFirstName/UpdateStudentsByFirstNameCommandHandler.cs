using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Contracts.Services;
using LibraryManagement.Application.Features.Students.Commands.UpdateStudentsByFirstName;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentsByFirstNameCommandHandler : IRequestHandler<UpdateStudentsByFirstNameCommand, UpdateStudentsByFirstNameResponse>
    {
        private readonly ILogger<UpdateStudentsByFirstNameCommandHandler> _logger;
        private readonly IStudentsService _studentsService;

        public UpdateStudentsByFirstNameCommandHandler(IStudentsService studentsService, ILogger<UpdateStudentsByFirstNameCommandHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public async Task<UpdateStudentsByFirstNameResponse> Handle(UpdateStudentsByFirstNameCommand request, CancellationToken cancellationToken)
        {
            var successMessage = $"Students were updated!";
            var response = new UpdateStudentsByFirstNameResponse();

            try
            {
                var students = await _studentsService.UpdateStudentsByFirstNameAsync();

                if (!students.Any())
                {
                    response.Success = false;
                    response.Message = $"Students were not updated";
                    _logger.LogError(response.Message);

                    return response;
                }

                response.Success = true;
                response.Students = students;
                response.Message = successMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Failed to update students";
                _logger.LogError(response.Message);

                return response;
            }

            _logger.LogInformation(successMessage);

            return response;
        }
    }
}
