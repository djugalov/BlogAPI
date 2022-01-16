using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Comment
{
    public class EditCommentRequestDto
    {
        [Required(ErrorMessage = "Id of the comment must be provided")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
