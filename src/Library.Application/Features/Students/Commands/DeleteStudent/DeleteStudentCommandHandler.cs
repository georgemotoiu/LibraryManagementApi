using AutoMapper;
using Library.Application.Responses;
using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, BaseResponse<string>>
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<DeleteStudentCommandHandler> _logger;

        public DeleteStudentCommandHandler(IStudentsService studentsService, ILogger<DeleteStudentCommandHandler> logger, IMapper mapper, IBorrowsService borrowsService)
        {
            _studentsService = studentsService;
            _logger = logger;
        }
        public async Task<BaseResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>("", true);
            try
            {
                var existingStudent = await _studentsService.GetStudentIdWithNoTrackingAsync(request.StudentId);
                if (existingStudent == null)
                {
                    response.Message = $"No Student found with id: {request.StudentId}";
                    response.Success = false;

                    return response;
                }

                await _studentsService.DeleteStudentAsync(existingStudent);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception while deleting student with ID: {studentId} -- {exMessage}", request.StudentId,
                    ex.Message);
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
