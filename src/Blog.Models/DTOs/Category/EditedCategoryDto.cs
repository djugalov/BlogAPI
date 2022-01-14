using System;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Category
{
    public class EditedCategoryDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
