﻿using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Post;
using Blog.BL.Queries.Post;
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

        [HttpGet]
        public async Task<IActionResult> GetPostById([FromQuery] GetPostByIdRequest request)
        {
            var response = await _mediator.Send(new GetPostByIdQuery(request));

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

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostRequest request)
        {
            var response = await _mediator.Send(new DeletePostCommand(request));

            return Ok(response);
        }
    }
}
