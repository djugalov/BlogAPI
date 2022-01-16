﻿using Blog.BL.Commands.Tag;
using Blog.BL.Queries.Tag;
using Blog.Models.Requests.Tag;
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

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTagFromPost(RemoveTagFromPostRequest request)
        {
            var response = await _mediator.Send(new RemoveTagFromPostCommand(request));
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag(DeleteTagRequest request)
        {
            var response = await _mediator.Send(new DeleteTagCommand(request));

            return Ok(response);
        }
    }
}
