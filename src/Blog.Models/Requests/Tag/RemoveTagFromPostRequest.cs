using Blog.Models.DTOs.Tag;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.Tag
{
    public class RemoveTagFromPostRequest
    {
        [JsonPropertyName("tagToBeRemovedFromPost")]
        public RemoveTagFromPostDto TagToBeRemovedFromPost { get; set; }
    }
}
