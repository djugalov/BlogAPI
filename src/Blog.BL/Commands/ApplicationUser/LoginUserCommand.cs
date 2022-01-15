using Blog.Models.Requests.ApplicationUser;
using Blog.Models.Responses.ApplicationUser;
using MediatR;

namespace Blog.BL.Commands.ApplicationUser
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public LoginUserCommand(LoginUserRequest request)
        {
            Request = request;
        }

        public LoginUserRequest Request { get; set; }
    }
}
