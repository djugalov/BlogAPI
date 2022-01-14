using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Category
{
    public class EditCategoryRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
