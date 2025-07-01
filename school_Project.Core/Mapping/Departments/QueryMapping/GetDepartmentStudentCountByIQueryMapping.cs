using school_Project.Core.Features.Department.Queries.Dtos;
using school_Project.Core.Features.Department.Queries.Models;
using school_Project.Data.Entities.Procedures;

namespace school_Project.Core.Mapping.Departments
{
    public partial class DepartmentsProfile
    {
        public void GetDepartmentStudentCountByIQueryMapping()
        {
            CreateMap<GetDepartmentStudentCountByIQuery, DepartmentProcParameter>().
                ForMember(d => d.DID, s => s.MapFrom(src => src.DID));

            CreateMap<DepartmentProc, GetDepartmentStudentCountByIQueryReposne>().
                ForMember(d => d.Name, s => s.MapFrom(src => src.GetLocalize(src.DNameAr, src.DNameEn)))
                  .ForMember(d => d.StudentCount, opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
