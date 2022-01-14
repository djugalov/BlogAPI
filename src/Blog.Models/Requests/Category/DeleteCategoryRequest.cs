using System;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Category
{
    public class DeleteCategoryRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
