using Blog.Models.DTOs.Comment;
using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Comment
{
    public class EditCommentRequest
    {
        [JsonPropertyName("comment")]
        public EditCommentRequestDto Comment { get; set; }
    }
}
