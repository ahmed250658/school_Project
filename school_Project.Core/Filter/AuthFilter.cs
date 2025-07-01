using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using school_Project.Data.Entities.Identity;
using school_Project.Service.AuthService.Abstracts;

namespace school_Project.Core.Filter
{

    public class AuthFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<Users> _userManager;
        public AuthFilter(ICurrentUserService currentUserService, UserManager<Users> userManager)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == true)
            {
                var Role = await _currentUserService.GetCurrentUserRolesAsync();
                if (Role.All(x => x != "User"))
                {
                    context.Result = new ObjectResult("Forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }

            }
            else
            {
                await next();
            }
        }
    }
}
