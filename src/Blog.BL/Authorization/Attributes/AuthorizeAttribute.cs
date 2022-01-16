using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Blog.BL.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; } = string.Empty;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var userId = context.HttpContext.Items["UserId"];

            var role = context.HttpContext.Items["Role"] != null ? context.HttpContext.Items["Role"].ToString() : string.Empty;

            bool isUserAuthorized = IsUserAuthorized(userId, role);

            if (!isUserAuthorized)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        private bool IsUserAuthorized(object userId, string role)
        {
            var authorizedRoles = Roles.Split(',');

            if (userId != null)
            {
                if (Roles == string.Empty) return true;

                foreach (var authorizedRole in authorizedRoles)
                {
                    if (authorizedRole == role)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
