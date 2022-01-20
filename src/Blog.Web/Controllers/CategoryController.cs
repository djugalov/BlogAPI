using Blog.BL.Authorization.Attributes;
using Blog.BL.Commands.Category;
using Blog.BL.Queries.Category;
using Blog.Models.Requests.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById([FromQuery] Guid id)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Category]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            var response = await _mediator.Send(new AddCategoryCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Category]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryRequest request)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Category]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditCategory([FromBody] EditCategoryRequest request)
        {
            var response = await _mediator.Send(new EditCategoryCommand(request));

            if (!response.IsSuccess)
            {
                _logger.LogError($"[BlogAPI/Category]: {response.ResponseMessage}");

                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
