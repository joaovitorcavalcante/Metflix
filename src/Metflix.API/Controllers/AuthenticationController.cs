using MediatR;
using Metflix.Application.Authentication.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace Metflix.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
