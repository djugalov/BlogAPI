using System;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Comment
{
    public class CommentDetailsDto
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }

        [JsonPropertyName("upvotes")]
        public int Upvotes { get; set; }

        [JsonPropertyName("downvotes")]
        public int Downvotes { get; set; }
    }
}
