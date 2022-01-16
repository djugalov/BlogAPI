using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Comment
{
    public class GetCommentsForPostRequest
    {
        [Required]
        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }
    }
}
