using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models.DTOs.ApplicationUser
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "First name must be provided")]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle name must be provided")]
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name must be provided")]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username must be provided")]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email must be provided")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must be provided")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
