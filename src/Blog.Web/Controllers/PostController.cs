using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Post;
using Blog.BL.Queries.Post;
using Blog.Models.Requests.Post;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostController> _logger;

        public PostController(IMediator mediator, ILogger<PostController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostById([FromQuery] GetPostByIdRequest request)
        {
            var response = await _mediator.Send(new GetPostByIdQuery(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Post]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var response = await _mediator.Send(new GetAllPostQuery());

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var response = await _mediator.Send(new CreatePostCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Post]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostRequest request)
        {
            var response = await _mediator.Send(new DeletePostCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Post]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
