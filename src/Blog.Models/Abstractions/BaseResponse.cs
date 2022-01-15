using System.Text.Json.Serialization;

namespace Blog.Models.Abstractions
{
    public abstract class BaseResponse
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("responseMessage")]
        public string ResponseMessage { get; set; }
    }
}
