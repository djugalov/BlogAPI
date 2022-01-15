using Blog.BL.Authorization.Contracts;
using Blog.BL.Helpers;
using Blog.Data.DbModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Blog.BL.Authorization
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly AppSettings _appSettings;
        public JwtTokenProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenGenerationKey = Encoding.ASCII.GetBytes(_appSettings.AuthSecret);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenGenerationKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            var serializedToken = tokenHandler.WriteToken(token);

            return serializedToken;
        }

        public string ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenGenerationKey = Encoding.ASCII.GetBytes(_appSettings.AuthSecret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenGenerationKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var userId = ((JwtSecurityToken)validatedToken).Claims.First(x => x.Type == "id").Value;

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}
