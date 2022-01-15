using Blog.BL.Authorization.Contracts;
using Blog.Data;
using Blog.Models.Responses.ApplicationUser;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Blog.BL.Commands.ApplicationUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly BlogDbContext _context;
        private readonly IJwtTokenProvider _jwtTokenProvider;

        public LoginUserCommandHandler(BlogDbContext context, IJwtTokenProvider jwtTokenProvider)
        {
            _context = context;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Username == loginUserCommand.Request.User.Username, CancellationToken.None);

            if (user == null || !BCryptNet.Verify(loginUserCommand.Request.User.Password, user.Password))
            {
                return new LoginUserResponse
                {
                    IsSuccess = false,
                    ResponseMessage = "Username or password is wrong"
                };
            }

            return new LoginUserResponse
            {
                IsSuccess = true,
                ResponseMessage = "Login was successful",
                Token = _jwtTokenProvider.GenerateToken(user)
            };
        }
    }
}
