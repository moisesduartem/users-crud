using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Application.Commands;
using UsersApi.Application.Queries;

namespace UsersApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUsersQuery(), cancellationToken);

            if (result.Count() == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
