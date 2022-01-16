using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Tag
{
    public class RemoveTagFromPostDto
    {
        [Required(ErrorMessage = "Tag Id must be provided")]
        [JsonPropertyName("tagId")]
        public Guid TagId { get; set; }

        [Required(ErrorMessage = "Post Id must be provided")]
        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }
    }
}
