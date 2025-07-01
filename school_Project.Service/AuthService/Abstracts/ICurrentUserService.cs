using school_Project.Data.Entities.Identity;

namespace school_Project.Service.AuthService.Abstracts
{
    public interface ICurrentUserService
    {
        public Task<Users> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
