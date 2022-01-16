using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Comment;
using Blog.BL.Queries.Comment;
using Blog.Models.Requests.Comment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsForPost([FromQuery] GetCommentsForPostRequest request)
        {
            var response = await _mediator.Send(new GetCommentsForPostQuery(request));

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            var response = await _mediator.Send(new CreateCommentCommand(request));

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(EditCommentRequest request)
        {
            var response = await _mediator.Send(new EditCommentCommand(request));

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteComment(DeleteCommentRequest request)
        {
            var response = await _mediator.Send(new DeleteCommentCommand(request));

            return Ok(response);
        }
    }
}
