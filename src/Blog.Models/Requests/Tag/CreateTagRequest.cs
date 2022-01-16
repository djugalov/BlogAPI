using Blog.Models.DTOs.Tag;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Tag
{
    public class CreateTagRequest
    {
        [JsonPropertyName("tag")]
        public CreateTagDto Tag { get; set; }
    }
}
