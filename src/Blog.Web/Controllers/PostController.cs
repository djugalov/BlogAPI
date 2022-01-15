using Blog.BL.Commands.Post;
using Blog.Models.Requests.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var response = await _mediator.Send(new CreatePostCommand(request));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostRequest request)
        {
            var response = await _mediator.Send(new DeletePostCommand(request));

            return Ok(response);
        }
    }
}
