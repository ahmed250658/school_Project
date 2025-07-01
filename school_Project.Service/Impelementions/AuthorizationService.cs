using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Helper;
using school_Project.Data.Requests;
using school_Project.Infrastructure.Data;
using school_Project.Service.Abstracts;

namespace school_Project.Service.Impelementions
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Users> _userManager;
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<Users> userManager, ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        #endregion

        #region Handle Function
        public async Task<string> AddRoleAsync(string roleName)
        {
            var IdentityRole = new Role();
            IdentityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(IdentityRole);
            if (result.Succeeded) return "Success";
            return "Failed";
        }


        public async Task<bool> IsRoleExsitByName(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return false;
            return true;
            // var role = await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<string> EditRoleAsync(EditRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
                return "NotFound";
            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<string> DeleteRoleAsync(int id)
        {
            //check if the role is exist
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return "NotFound";
            //check is any user has this role
            var user = await _userManager.GetUsersInRoleAsync(role.Name);
            if (user != null && user.Count() > 0) return "Used";
            //Delete
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;

        }

        public async Task<List<Role>> GetRolesList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public Task<bool> IsRoleExsitById(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return role;
        }

        public async Task<ManagerUserRolesResponse> GetManagerUserRoles(Users user)
        {
            var response = new ManagerUserRolesResponse();
            var rolesList = new List<Roles>();
            //Roles
            var roles = await _roleManager.Roles.ToListAsync();

            response.UserId = user.Id;
            foreach (var role in roles)
            {
                var userrole = new Roles();
                userrole.Id = role.Id;
                userrole.Name = role.Name;
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userrole.HasRole = true;
                }
                else
                {
                    userrole.HasRole = false;
                }
                rolesList.Add(userrole);
            }
            response.Roles = rolesList;
            return response;
        }

        public async Task<string> UpdateUserRoles(UpdateUserRolesResponse request)
        {
            var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //Get User
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "UserIsNull";
                }
                //get user Old Roles
                var userRoles = await _userManager.GetRolesAsync(user);
                //Delete OldRoles
                var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removeResult.Succeeded)
                    return "FailedToRemoveOldRoles";
                var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.Name);
                //Add New Roles
                var addRolesresult = await _userManager.AddToRolesAsync(user, selectedRoles);
                if (!addRolesresult.Succeeded)
                    return "FailedToAddNewRoles";
                await tran.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {

                await tran.RollbackAsync();
                return "FailedToAddRoles";
            }
        }

        public async Task<ManagerUserClaimsResponse> GetManagerUserClaims(Users user)
        {
            var response = new ManagerUserClaimsResponse();
            var userclaimsList = new List<UserClaims>();
            //Get User Claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in ClaimStore.claims)
            {
                var userclaim = new UserClaims();
                userclaim.Type = claim.Type;
                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    userclaim.Value = true;
                }
                else
                {
                    userclaim.Value = true;
                }
                userclaimsList.Add(userclaim);
            }
            response.userClaims = userclaimsList;
            // return Result
            return response;
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimsResponse request)
        {
            var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return "UserIsNull";
                }
                //remove old Claims
                var userClaims = await _userManager.GetClaimsAsync(user);
                var removeClaimsResult = await _userManager.RemoveClaimsAsync(user, userClaims);
                if (!removeClaimsResult.Succeeded)
                    return "FailedToRemoveOldClaims";
                var claims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

                var addUserClaimResult = await _userManager.AddClaimsAsync(user, claims);
                if (!addUserClaimResult.Succeeded)
                    return "FailedToAddNewClaims";

                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateClaims";
            }
        }

        #endregion

    }
}
