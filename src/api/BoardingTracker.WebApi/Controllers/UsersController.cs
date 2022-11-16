using BoardingTracker.Application.Users.Commands.CreateUser;
using BoardingTracker.Application.Users.Commands.DeleteUser;
using BoardingTracker.Application.Users.Commands.UpdateUser;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Application.Users.Queries.GetAllUsers;
using BoardingTracker.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingTracker.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsersList))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await Mediator.Send(createUserRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersList))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await Mediator.Send(new DeleteUserRequest { Id = id });
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersList))]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await Mediator.Send(updateUserRequest);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetUsers());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersList))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetUserByIdRequest { Id = id });
            return Ok(result);
        }
    }
}
