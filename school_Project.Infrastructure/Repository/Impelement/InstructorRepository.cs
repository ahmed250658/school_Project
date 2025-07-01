using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;

namespace school_Project.Infrastructure.Repository.Impelement
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Field
        private readonly DbSet<Instructor> _instructor;
        #endregion
        #region Constructor DB
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _instructor = dbContext.Set<Instructor>();
        }
        #endregion
    }
}
