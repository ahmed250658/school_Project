using school_Project.Core.Features.Students.Queries.Dtos;
using school_Project.Data.Entities;

namespace school_Project.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedResponse>().
               ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.GetLocalize(src.Department.DNameAr, src.Department.DNameEn)))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalize(src.NameAr, src.NameEn)))
               .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}

