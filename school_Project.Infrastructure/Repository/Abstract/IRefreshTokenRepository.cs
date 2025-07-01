using school_Project.Data.Entities.Identity;
using school_Project.Infrastructure.Base;

namespace school_Project.Infrastructure.Repository.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
