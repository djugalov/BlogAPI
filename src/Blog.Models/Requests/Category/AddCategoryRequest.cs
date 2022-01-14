using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Category
{
    public class AddCategoryRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
