using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.Tag
{
    public class CreateTagDto
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
