using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Category
{
    public class AddCategoryRequest
    {
        [Required(ErrorMessage = "Name must be specified")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
