using System;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Post
{
    public class CreatePostDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("authorId")]
        public Guid AuthorId { get; set; }

    }
}
