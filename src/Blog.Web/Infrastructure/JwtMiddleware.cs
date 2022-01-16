using Blog.BL.Authorization.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Infrastructure
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtTokenProvider jwtTokenProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var jwtValidationDto = jwtTokenProvider.ValidateToken(token);

            if (jwtValidationDto?.UserId != null)
            {
                context.Items["UserId"] = jwtValidationDto.UserId;
                context.Items["Role"] = jwtValidationDto.Role;
            }

            await _next(context);
        }
    }
}
