using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities.Procedures;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract.Abstractproc;
using StoredProcedureEFCore;

namespace school_Project.Infrastructure.Repository.Impelement.ImpelementProc
{
    // This is the implementation of the DepartmentProcRepository which handles the retrieval of department procedure data.
    public class DepartmentProcRepository : IDepartmentProcRepository
    {
        #region Field
        private readonly ApplicationDbContext _dbContext;
        #endregion
        #region Constructor 
        public DepartmentProcRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region Handle Function
        public async Task<IReadOnlyList<DepartmentProc>> GetDepartmentProcAsync(DepartmentProcParameter parameter)
        {
            var rows = new List<DepartmentProc>();
            await _dbContext.LoadStoredProc(nameof(DepartmentProc)).
                 AddParam(nameof(DepartmentProcParameter.DID), parameter.DID)
                 .ExecAsync(async r => rows = await r.ToListAsync<DepartmentProc>());
            return rows;
        }
        #endregion

    }
}
