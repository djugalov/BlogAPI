using Blog.Models.Requests.ApplicationUser;
using Blog.Models.Responses.ApplicationUser;
using MediatR;

namespace Blog.BL.Commands.ApplicationUser
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public RegisterUserCommand(RegisterUserRequest request)
        {
            Request = request;
        }

        public RegisterUserRequest Request { get; set; }
    }
}
