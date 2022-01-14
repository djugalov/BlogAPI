using Blog.Models.DTOs.Category;
using System.Collections.Generic;

namespace Blog.Models.Responses.Category
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<BaseCategoryDto> Categories { get; set; }
    }
}
