using AutoMapper;

namespace school_Project.Core.Mapping.Instructorss
{
    public partial class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            AddInstructorCommandMapping();
        }
    }
}
