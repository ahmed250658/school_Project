using school_Project.Core.Features.Department.Queries.Dtos;
using school_Project.Data.Entities.Views;

namespace school_Project.Core.Mapping.Departments
{
    public partial class DepartmentsProfile
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentCountResponse>().
                ForMember(d => d.Name, s => s.MapFrom(src => src.GetLocalize(src.DNameAr, src.DNameEn)))
                  .ForMember(d => d.StudentCount, opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
