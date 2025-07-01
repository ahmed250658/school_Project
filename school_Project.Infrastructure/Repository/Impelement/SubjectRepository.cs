using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;

namespace school_Project.Infrastructure.Repository.Impelement
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        private readonly DbSet<Subjects> _subjects;
        #endregion
        #region Constructor
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subjects = dbContext.Set<Subjects>();
        }
        #endregion
    }
}