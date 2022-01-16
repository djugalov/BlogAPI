using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Comment;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            var response = await _mediator.Send(new CreateCommentCommand(request));

            return Ok(response);
        }
    }
}
