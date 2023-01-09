using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.Models;
using LibraryManagement.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentCommandResponse>
    {
        private readonly IStudentsService _studentsService;
        private readonly IBorrowsService _borrowsService;
        private readonly ILogger<AddStudentCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddStudentCommandHandler(IStudentsService studentsService, ILogger<AddStudentCommandHandler> logger, IMapper mapper, IBorrowsService borrowsService)
        {
            _studentsService = studentsService;
            _logger = logger;
            _mapper = mapper;
            _borrowsService = borrowsService;
        }
        public async Task<AddStudentCommandResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new AddStudentCommandResponse();
            try
            {
                var student = await _studentsService.AddStudentAsync(request.Model);
                _logger.LogInformation($"Added student {student.Id} with name {student.FirstName} {student.LastName}.");                

                if (student.Borrows.Any())
                {
                    request.Model.Borrows.ToList().ForEach(s => s.StudentId = student.Id);
                    foreach (var borrow in request.Model.Borrows)
                    {
                        await _borrowsService.AddBorrowAsync(borrow);
                        _logger.LogInformation($"Added borrowed book {borrow.BookId} for {student.FirstName} {student.LastName}.");
                    }
                }

                createStudentCommandResponse.Student = _mapper.Map<StudentDto>(student);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception while adding student with id: {firstName} {lastName} -- {exMessage}", request.Model.FirstName,
                    request.Model.LastName, e.Message);
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
