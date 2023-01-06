using Library.Application.Features.Students.Queries.GetStudent;
using Library.Application.Features.Students.Queries.GetStudents;
using Library.Application.Models;
using LibraryManagement.Application.Features.Students.Commands.AddStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var dtos = await _mediator.Send(new GetStudentsQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var getStudentQuery = new GetStudentQuery() { Id = id };
            return Ok(await _mediator.Send(getStudentQuery));
        }

        [HttpPost(Name = "AddStudent")]
        public async Task<ActionResult<AddStudentCommandResponse>> Create([FromBody] AddStudentCommand addStudentCommand)
        {
            var response = await _mediator.Send(addStudentCommand);            
            return CreatedAtRoute("GetStudentById", new { id = response.StudentId });
        }
    }
}
