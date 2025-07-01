using school_Project.Data.Entities.Procedures;

namespace school_Project.Infrastructure.Repository.Abstract.Abstractproc
{
    // This Is Abstract Repository for DepartmentProc
    public interface IDepartmentProcRepository
    {
        public Task<IReadOnlyList<DepartmentProc>> GetDepartmentProcAsync(DepartmentProcParameter parameter);
    }
}
