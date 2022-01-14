using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Category
{
    public class DeleteCategoryResponse
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("responseMessage")]
        public string DeleteCategoryResponseMessage { get; set; }
    }
}
