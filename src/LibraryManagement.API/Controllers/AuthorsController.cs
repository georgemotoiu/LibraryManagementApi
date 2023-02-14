using Library.Application.Features.Students.Queries.GetStudents;
using Library.Application.Models;
using LibraryManagement.Application.Features.Authors.Queries.GetMostBorrowedAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("top", Name = "GetMostBorrowedAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetMostBorrowedAuthors()
        {
            var authors = await _mediator.Send(new GetMostBorrowedAuthorsQuery());
            return Ok(authors);
        }
    }
}
