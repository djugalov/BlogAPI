using Blog.Models.Abstractions;
using Blog.Models.DTOs.Tag;
using System.Text.Json.Serialization; 

namespace Blog.Models.Responses.Tag
{
    public class CreateTagResponse : BaseResponse
    {
        [JsonPropertyName("tag")]
        public TagDetailsDto Tag { get; set; }
    }
}
