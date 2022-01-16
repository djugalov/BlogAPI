using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Content should be provided to the comment")]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Comment should be related to a post")]
        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }
    }
}
