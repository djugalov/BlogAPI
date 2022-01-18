using Blog.BL.Commands.Tag;
using Blog.BL.Queries.Tag;
using Blog.Models.Requests.Tag;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TagController> _logger;

        public TagController(IMediator mediator, ILogger<TagController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTagsPerPost([FromQuery] GetAllTagsPerPostRequest request)
        {
            var response = await _mediator.Send(new GetAllTagsPerPostQuery(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Tag]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var response = await _mediator.Send(new GetAllTagsQuery());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagRequest request)
        {
            var response = await _mediator.Send(new CreateTagCommand(request));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyTagsToPost(ApplyTagsToPostRequest request)
        {
            var response = await _mediator.Send(new ApplyTagsToPostCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Tag]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagFromPost(RemoveTagFromPostRequest request)
        {
            var response = await _mediator.Send(new RemoveTagFromPostCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Tag]: {response.ResponseMessage}");

                return BadRequest(response);
            }
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag(DeleteTagRequest request)
        {
            var response = await _mediator.Send(new DeleteTagCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Tag]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
