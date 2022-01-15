using Blog.BL.Authorization.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtTokenProvider.ValidateToken(token);

            if (userId != null)
            {
                context.Items["UserId"] = userId;
            }

            await _next(context);
        }
    }
}
