using Blog.BL.Commands.ApplicationUser;
using Blog.Models.Requests.ApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : Controller
    {
        private readonly IMediator _mediator;
        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var response = await _mediator.Send(new RegisterUserCommand(request));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            //Testy/Test123!
            var response = await _mediator.Send(new LoginUserCommand(request));

            return Ok(response);
        }
    }
}
