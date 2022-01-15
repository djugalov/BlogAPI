using Blog.Models.Abstractions;

namespace Blog.Models.Responses.ApplicationUser
{
    public class LoginUserResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
