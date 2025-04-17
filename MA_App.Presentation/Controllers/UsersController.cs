using MA_App.Application.Users.DTOs;
using MA_App.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MA_App.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
    }
}
