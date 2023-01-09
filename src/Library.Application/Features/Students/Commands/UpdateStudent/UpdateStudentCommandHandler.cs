using System;
using System.Threading;
using System.Threading.Tasks;
using Library.Application.Responses;
using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, BaseResponse<string>>
    {
        private readonly ILogger<UpdateStudentCommandHandler> _logger;
        private readonly IStudentsService _studentsService;

        public UpdateStudentCommandHandler(IStudentsService studentsService, ILogger<UpdateStudentCommandHandler> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public async Task<BaseResponse<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var successMessage = $"Updated student with id: {request.StudentId}";
            var response = new BaseResponse<string>("", true);

            try
            {
                var student = await _studentsService.GetStudentIdWithNoTrackingAsync(request.StudentId);

                if (student == null)
                {
                    response.Success = false;
                    response.Message = $"Student with id: {request.StudentId} doesn't exist";
                    _logger.LogError(response.Message);

                    return response;
                }

                await _studentsService.UpdateStudentAsync(request.Model);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Failed update on contest id: {request.StudentId} - {ex.Message}";
                _logger.LogError(response.Message);

                return response;
            }

            _logger.LogInformation(successMessage);

            return response;
        }
    }

}
