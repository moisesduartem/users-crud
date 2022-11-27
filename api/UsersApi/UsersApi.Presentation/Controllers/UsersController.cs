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
            var result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                _ => (IActionResult) StatusCode(StatusCodes.Status201Created),
                failure => StatusCode(StatusCodes.Status500InternalServerError, failure)
            );
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Create(int userId, UpdateUserCommand body, CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand
            {
                Id = userId,
                FirstName = body.FirstName,
                LastName = body.LastName,
                BirthDate = body.BirthDate,
                Email = body.Email,
                Scholarity = body.Scholarity
            };

            var result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                _ => (IActionResult) NoContent(),
                failure => StatusCode(StatusCodes.Status500InternalServerError, failure)
            );
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand { UserId = userId };
            
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
