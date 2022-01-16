using Blog.Models.Abstractions;
using Blog.Models.DTOs.Comment;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Post
{
    public class EditCommentResponse : BaseResponse
    {

        [JsonPropertyName("comment")]
        public CommentDetailsDto Comment { get; set; }
    }
}
