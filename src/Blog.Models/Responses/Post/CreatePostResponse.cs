using Blog.Models.DTOs.Post;
using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Responses.Post
{
    public class CreatePostResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("post")]
        public CreatePostDto Post { get; set; }

        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("responseMessage")]
        public string ResponseMessage { get; set; }
    }
}
