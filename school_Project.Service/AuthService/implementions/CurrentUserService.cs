using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Helper;
using school_Project.Service.AuthService.Abstracts;

namespace school_Project.Service.AuthService.implementions
{
    public class CurrentUserService : ICurrentUserService
    {
        #region fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Users> _userManager;
        #endregion

        #region Constructorr
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<Users> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion

        #region Handle Function
        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public async Task<Users> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            return user;
        }

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claims => claims.Type == nameof(UserClaimModel.Id)).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }
            return int.Parse(userId);
        }
        #endregion

    }
}
