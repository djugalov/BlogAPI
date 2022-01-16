using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Tag
{
    public class ApplyTagsToPostDto
    {
        [Required(ErrorMessage = "Tags ids must be provided")]
        [JsonPropertyName("tagsIds")]
        public IEnumerable<Guid> TagsIds { get; set; }

        [Required(ErrorMessage = "Post ID must be provided")]
        [JsonPropertyName("post")]
        public Guid PostId { get; set; }
    }
}
