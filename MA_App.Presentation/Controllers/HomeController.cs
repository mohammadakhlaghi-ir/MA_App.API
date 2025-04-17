using MA_App.Application.AppInfos.DTOs;
using MA_App.Application.AppInfos.Queries;
using MA_App.Application.Users.DTOs;
using MA_App.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MA_App.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Retrieves the application information.
        /// </summary>
        /// <returns>An object containing app metadata like name, version, and other info.</returns>
        /// <response code="200">Returns the application info</response>
        [HttpGet("GetAppInfo")]
        [ProducesResponseType(typeof(AppInfoDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<AppInfoDto>> GetAppInfo()
        {
            var appInfo = await _mediator.Send(new GetAppInfoQuery());
            return Ok(appInfo);
        }
    }
}
