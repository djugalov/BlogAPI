using Blog.Models.DTOs.Tag;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Tag
{
    public class ApplyTagsToPostRequest
    {
        [JsonPropertyName("tagsToApply")]
        public ApplyTagsToPostDto TagsToApply { get; set; }
    }
}
