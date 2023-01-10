using Library.Application.Features.Students.Queries.GetStudent;
using Library.Application.Features.Students.Queries.GetStudents;
using Library.Application.Models;
using LibraryManagement.Application.Features.Students.Commands.AddStudent;
using LibraryManagement.Application.Features.Students.Commands.DeleteStudent;
using LibraryManagement.Application.Features.Students.Commands.UpdateStudent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var dtos = await _mediator.Send(new GetStudentsQuery());
            return Ok(dtos);
        }
        
        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var command = new GetStudentQuery() { Id = id };
            var result = await _mediator.Send(command);

            return result.Success? Ok(result) : NotFound(result);
        }

        [Authorize]
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AddStudentCommandResponse>> Create([FromBody] AddStudentCommand command)
        {
            var response = await _mediator.Send(command);            
            return CreatedAtRoute("GetStudentById", new { id = response.Student.Id }, command);
        }

        [Authorize]
        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? NoContent() : BadRequest(result.Message);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteStudentCommand() { StudentId = id };
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result.Message);
        }
    }
}
