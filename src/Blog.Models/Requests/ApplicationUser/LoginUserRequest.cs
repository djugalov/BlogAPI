using Blog.Models.DTOs.ApplicationUser;
using System.Text.Json.Serialization;

namespace Blog.Models.Requests.ApplicationUser
{
    public class LoginUserRequest
    {
        [JsonPropertyName("user")]
        public LoginUserDto User { get; set; }
    }
}
