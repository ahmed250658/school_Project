using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Data.Entities.Procedures;
using school_Project.Data.Entities.Views;
using school_Project.Infrastructure.Repository.Abstract;
using school_Project.Infrastructure.Repository.Abstract.Abstractproc;
using school_Project.Infrastructure.Repository.Abstract.AbstractView;
using school_Project.Service.Abstracts;

namespace school_Project.Service.Impelementions
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IViewReporsitory<ViewDepartment> _viewDepartment;
        private readonly IDepartmentProcRepository _departmentProcRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IViewReporsitory<ViewDepartment> viewDepartment, IDepartmentProcRepository departmentProcRepository)
        {
            _departmentRepository = departmentRepository;
            _viewDepartment = viewDepartment;
            _departmentProcRepository = departmentProcRepository;
        }
        #endregion
        #region Constructor
        #endregion
        #region Handle Function
        public async Task<Department> GetDepartmentByID(int id)
        {
            var dpet = await _departmentRepository.GetTableNoTracking().
                                 Where(x => x.DID.Equals(id)).
                                 Include(x => x.DepartmentSubjects).ThenInclude(V => V.Subjects).
                                 Include(c => c.Instructors).
                                 Include(f => f.Instructor).FirstOrDefaultAsync();
            return dpet;

        }

        public async Task<IReadOnlyList<DepartmentProc>> GetDepartmentProcAsync(DepartmentProcParameter parameter)
        {
            return await _departmentProcRepository.GetDepartmentProcAsync(parameter);
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentAsync()
        {
            var viewdepart = await _viewDepartment.GetTableNoTracking().ToListAsync();
            return viewdepart;
        }

        public async Task<bool> IsDepartmentIdExist(int depatId)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(depatId));
        }
        #endregion
    }
}
