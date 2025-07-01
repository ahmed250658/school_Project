using school_Project.Data.Entities.Identity;

namespace school_Project.Service.Abstracts
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(Users user, string password);
    }
}
