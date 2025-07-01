using school_Project.Core.Features.Department.Queries.Dtos;
using school_Project.Data.Entities;

namespace school_Project.Core.Mapping.Departments
{
    public partial class DepartmentsProfile
    {
        public void GetDepartmentByIDMapping()
        {
            CreateMap<Department, GetDepartmentByIDQueryResponse>().
                 ForMember(d => d.DName, s => s.MapFrom(src => src.GetLocalize(src.DNameAr, src.DNameEn))).
                  ForMember(d => d.ID, s => s.MapFrom(src => src.DID)).
                   ForMember(d => d.ManagerName, s => s.MapFrom(src => src.Instructor.GetLocalize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                   .ForMember(d => d.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                   //.ForMember(d => d.StudentList, opt => opt.MapFrom(src => src.Students))
                   .ForMember(d => d.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmetSubject, SubjectResponse>().
                ForMember(d => d.ID, s => s.MapFrom(src => src.SubID)).
                ForMember(d => d.Name, s => s.MapFrom(src => src.Subjects.GetLocalize(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));

            //CreateMap<Student, StudentResponse>().
            //    ForMember(d => d.ID, s => s.MapFrom(src => src.StudID)).
            //    ForMember(d => d.Name, s => s.MapFrom(src => src.GetLocalize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstructorResponse>().
                ForMember(d => d.ID, s => s.MapFrom(src => src.InsID)).
                ForMember(d => d.Name, s => s.MapFrom(src => src.GetLocalize(src.ENameAr, src.ENameEn)));
        }
    }
}
