using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Tag
{
    public class GetAllTagsPerPostRequest
    {
        [Required(ErrorMessage = "Post Id must be provided")]
        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }
    }
}
