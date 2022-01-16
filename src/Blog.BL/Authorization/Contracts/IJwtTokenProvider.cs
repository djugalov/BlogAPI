using Blog.Data.DbModels;
using Blog.Models.DTOs.ApplicationUser;
using System;

namespace Blog.BL.Authorization.Contracts
{
    public interface IJwtTokenProvider
    {
        public string GenerateToken(ApplicationUser user);

        public JwtValidationDto ValidateToken(string token);
    }
}
