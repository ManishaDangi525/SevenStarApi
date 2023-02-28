using SevenStarDtos.DTOs;
using SevenStarFramework.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStar.Utils
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (LoginDTO)context.HttpContext.Items["CurrentUser"];
            if (user == null)
                throw new UnauthorizedException("Unauthorized");
        }
    }
}
