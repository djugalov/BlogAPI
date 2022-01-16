using Blog.Models.Abstractions;
using Blog.Models.DTOs.Comment;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Comment
{
    public class GetCommentByIdResponse : BaseResponse
    {
        [JsonPropertyName("comment")]
        public CommentDetailsDto Comment { get; set; }
    }
}
