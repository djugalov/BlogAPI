using System;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Category
{
    public class BaseCategoryDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
