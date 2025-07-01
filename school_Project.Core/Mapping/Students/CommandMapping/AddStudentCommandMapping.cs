using school_Project.Core.Features.Students.Commands.Models;
using school_Project.Data.Entities;

namespace school_Project.Core.Mapping.Students

{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>().
                ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId)).
                ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr)).
                ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn));

        }
    }
}
