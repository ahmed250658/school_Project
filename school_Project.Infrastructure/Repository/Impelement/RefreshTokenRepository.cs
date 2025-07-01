using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities.Identity;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;

namespace school_Project.Infrastructure.Repository.Impelement
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private readonly DbSet<UserRefreshToken> _userTokens;
        #endregion
        #region Constructor

        #endregion
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
