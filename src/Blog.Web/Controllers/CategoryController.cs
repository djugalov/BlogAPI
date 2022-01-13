using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpPost]
        public IActionResult AddCategory()
        {
            return Ok();
        }
    }
}
