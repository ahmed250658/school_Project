using school_Project.Data.Entities;
using school_Project.Data.Entities.Procedures;
using school_Project.Data.Entities.Views;

namespace school_Project.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByID(int id);
        public Task<bool> IsDepartmentIdExist(int depatId);
        public Task<List<ViewDepartment>> GetViewDepartmentAsync();
        public Task<IReadOnlyList<DepartmentProc>> GetDepartmentProcAsync(DepartmentProcParameter parameter);
    }
}
