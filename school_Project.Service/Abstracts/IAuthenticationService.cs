using System.IdentityModel.Tokens.Jwt;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Helper;

namespace school_Project.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetJwtToken(Users user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<JwtAuthResult> GetRefreshToken(Users user, JwtSecurityToken jwtToken, DateTime? expiredata, string RefreshToken);
        public Task<(string, DateTime?)> VaildateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<string> VaildateToken(string AccessToken);
        public Task<string> ConfirmEmail(int? userId, string Code);
        public Task<string> SendResetPassword(string Email);
        public Task<string> ConfirmResetPassword(string Code, string Email);
        public Task<string> ResetPassword(string Email, string password);
    }
}
