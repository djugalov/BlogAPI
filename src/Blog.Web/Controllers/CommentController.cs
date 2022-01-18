using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Comment;
using Blog.BL.Queries.Comment;
using Blog.Models.Requests.Comment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CommentController> _logger;
        public CommentController(IMediator mediator, ILogger<CommentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsForPost([FromQuery] GetCommentsForPostRequest request)
        {
            var response = await _mediator.Send(new GetCommentsForPostQuery(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Comment]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentById([FromQuery] GetCommentByIdRequest request)
        {
            var response = await _mediator.Send(new GetCommentByIdQuery(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Comment]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            var response = await _mediator.Send(new CreateCommentCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Comment]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(EditCommentRequest request)
        {
            var response = await _mediator.Send(new EditCommentCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Comment]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteComment(DeleteCommentRequest request)
        {
            var response = await _mediator.Send(new DeleteCommentCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Comment]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
