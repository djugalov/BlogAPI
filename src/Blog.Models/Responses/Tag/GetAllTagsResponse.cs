using Blog.Models.DTOs.Tag;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Tag
{
    public class GetAllTagsResponse
    {
        [JsonPropertyName("tags")]
        public IEnumerable<TagDetailsDto> Tags { get; set; }
    }
}
