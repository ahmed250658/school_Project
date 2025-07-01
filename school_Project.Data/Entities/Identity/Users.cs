using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;

namespace school_Project.Data.Entities.Identity
{
    public class Users : IdentityUser<int>
    {
        public Users()
        {
            RefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        [EncryptColumn]
        public string? Code { get; set; }
        [InverseProperty("Users")]
        public virtual ICollection<UserRefreshToken> RefreshTokens { get; set; }
    }
}
