using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;

namespace school_Project.Infrastructure.Repository.Impelement
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        public readonly DbSet<Department> _departmentSet;
        #endregion
        #region Constructor
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _departmentSet = dbContext.Set<Department>();
        }
        #endregion
    }
}
