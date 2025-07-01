using AutoMapper;

namespace school_Project.Core.Mapping.Departments
{
    public partial class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            GetDepartmentByIDMapping();
            GetDepartmentStudentCountMapping();
            GetDepartmentStudentCountByIQueryMapping();
        }
    }
}
