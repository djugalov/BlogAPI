using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyTagsToPost()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagFromPost()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag()
        {
            return Ok();
        }
    }
}
