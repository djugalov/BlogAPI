using Blog.Models.Abstractions;
using Blog.Models.DTOs.Comment;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Comment
{
    public class GetCommentsForPostResponse : BaseResponse
    {
        [JsonPropertyName("name")]
        public IEnumerable<CommentDetailsDto> Comments { get; set; }
    }
}
