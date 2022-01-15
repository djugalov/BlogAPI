using System;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Post
{
    public class PostDetailsDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("authorId")]
        public Guid AuthorId { get; set; }

        [JsonPropertyName("publishedOn")]
        public DateTime PublishedOn { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
