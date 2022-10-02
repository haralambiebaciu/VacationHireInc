using Application.User.Commands.CreateUser;
using Application.User.Commands.DeleteUser;
using Application.User.Commands.UpdateUser;
using Application.User.Queries.GetAllUsers;
using Application.User.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            var user = await Sender.Send(new GetUserQuery { Id = userId }, cancellationToken);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await Sender.Send(new GetUsersQuery(), cancellationToken);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new CreateUserCommand
            {
                Name = request.Name
            };

            var userId = await Sender.Send(user, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { userId }, userId);
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand
            {
                Id = userId
            };

            await Sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand
            {
                Id = userId,
                Name = request.Name
            };

            await Sender.Send(command, cancellationToken);

            return Ok();
        }
    }
}
