using Blog.BL.Commands.ApplicationUser;
using Blog.Models.Requests.ApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ApplicationUserController> _logger;
        public ApplicationUserController(IMediator mediator, ILogger<ApplicationUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var response = await _mediator.Send(new RegisterUserCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Login]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var response = await _mediator.Send(new LoginUserCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Login]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
