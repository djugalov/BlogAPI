using Blog.Models.DTOs.ApplicationUser;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.ApplicationUser
{
    public class RegisterUserRequest
    {
        [JsonPropertyName("user")]
        public RegisterUserDto User { get; set; }
    }
}
