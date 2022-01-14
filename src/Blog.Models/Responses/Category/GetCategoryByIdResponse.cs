using Blog.Models.DTOs.Category;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Category
{
    public class GetCategoryByIdResponse
    {
        [JsonPropertyName("category")]
        public BaseCategoryDto Category { get; set; }

        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("responseMessage")]
        public string GetCategoryByIdResponseMessage { get; set; }
    }
}
