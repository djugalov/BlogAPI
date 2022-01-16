using Blog.Data;
using Blog.Models.Responses.ApplicationUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Blog.BL.Commands.ApplicationUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly BlogDbContext _context;

        public RegisterUserCommandHandler(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            if(_context.ApplicationUsers.Any(x => x.Username == registerUserCommand.Request.User.Username))
            {
                return new RegisterUserResponse
                {
                    IsSuccess = false,
                    ResponseMessage = "User with this username already exist"
                };
            }

            var userData = registerUserCommand.Request.User;

            //To do -> move to automapper
            var user = new Blog.Data.DbModels.ApplicationUser
            {
                Username = userData.Username,
                FirstName = userData.FirstName,
                MiddleName = userData.MiddleName,
                LastName = userData.LastName,
                Email = userData.Email,
                Password = BCryptNet.HashPassword(userData.Password),
                AuthorUser = new Data.DbModels.User
                {
                    Username = userData.Username
                }
            };

            await _context.ApplicationUsers.AddAsync(user, CancellationToken.None);

            await _context.SaveChangesAsync(CancellationToken.None);

            return new RegisterUserResponse
            {
                IsSuccess = true,
                ResponseMessage = "User was registered successfully"
            };
        }
    }
}
