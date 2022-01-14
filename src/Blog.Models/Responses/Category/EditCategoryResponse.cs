using Blog.Models.DTOs.Category;
using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Category
{
    public class EditCategoryResponse
    {
        [JsonPropertyName("category")]
        public BaseCategoryDto Category { get; set; }

        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("responseMessage")]
        public string EditCategoryResponseMessage { get; set; }
    }
}
