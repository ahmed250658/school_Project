using school_Project.Core.Features.Students.Queries.Dtos;
using school_Project.Data.Entities;

namespace school_Project.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIDMapping()
        {
            CreateMap<Student, GetSingleStudent>().
               ForMember(d => d.DepartmentName, s => s.MapFrom(src => src.Department.GetLocalize(src.Department.DNameAr, src.Department.DNameEn)))
               .ForMember(d => d.Name, s => s.MapFrom(src => src.GetLocalize(src.NameAr, src.NameEn)));

        }
    }
}
