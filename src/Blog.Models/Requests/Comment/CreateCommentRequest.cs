using Blog.Models.DTOs.Comment;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Comment
{
    public class CreateCommentRequest
    {
        [JsonPropertyName("comment")]
        public CreateCommentDto Comment { get; set; }
    }
}
