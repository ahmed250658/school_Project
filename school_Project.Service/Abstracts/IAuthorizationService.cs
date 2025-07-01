using school_Project.Data.Entities.Identity;
using school_Project.Data.Requests;

namespace school_Project.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest request);
        public Task<string> DeleteRoleAsync(int id);
        public Task<bool> IsRoleExsitByName(string roleName);
        public Task<bool> IsRoleExsitById(int roleId);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int id);
        public Task<ManagerUserRolesResponse> GetManagerUserRoles(Users user);
        public Task<string> UpdateUserRoles(UpdateUserRolesResponse request);
        public Task<string> UpdateUserClaims(UpdateUserClaimsResponse request);
        public Task<ManagerUserClaimsResponse> GetManagerUserClaims(Users user);

    }
}
