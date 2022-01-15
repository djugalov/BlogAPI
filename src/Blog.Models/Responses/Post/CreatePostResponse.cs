using Blog.Models.Abstractions;
using Blog.Models.DTOs.Post;
using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Post
{
    public class CreatePostResponse : BaseResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("post")]
        public CreatePostDto Post { get; set; }
    }
}
