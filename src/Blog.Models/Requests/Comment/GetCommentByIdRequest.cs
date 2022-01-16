using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Comment
{
    public class GetCommentByIdRequest
    {
        [Required]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
