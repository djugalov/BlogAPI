using Blog.Models.Abstractions;
using Blog.Models.DTOs.Category;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Category
{
    public class EditCategoryResponse : BaseResponse
    {
        [JsonPropertyName("category")]
        public BaseCategoryDto Category { get; set; }
    }
}
