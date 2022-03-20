using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneApp.UserService.API.Controllers.Base;
using PhoneApp.UserService.Application.Users.Commands.CreateUser;
using PhoneApp.UserService.Application.Users.Commands.CreateContact;
using PhoneApp.UserService.Application.Users.Commands.DeleteContact;
using PhoneApp.UserService.Application.Users.Commands.DeleteUser;
using PhoneApp.UserService.Application.Users.Queries.GetUser;
using PhoneApp.UserService.Application.Users.Queries.ListUsers;

namespace PhoneApp.UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var deleteUserCommand = new DeleteUserCommand(id);
            var response = await _mediator.Send(deleteUserCommand);
            return Ok(response);
        }
        [HttpPost]
        [Route("contact/{id}")]
        public async Task<IActionResult> CreateContact([FromRoute] int id, [FromBody] CreateContactCommand createContactCommand)
        {
            createContactCommand.UserId = id;
            var response = await _mediator.Send(createContactCommand);
            return Ok(response);
        }
        [HttpDelete]
        [Route("contact/{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var deleteContactCommand = new DeleteContactCommand(id);
            var response = await _mediator.Send(deleteContactCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var filter = new ListUsersQuery();
            var response = await _mediator.Send(filter);
            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var request = new GetUserQuery(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

