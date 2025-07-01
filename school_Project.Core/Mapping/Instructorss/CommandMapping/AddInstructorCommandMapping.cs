using school_Project.Core.Features.Instructors.Command.Models;
using school_Project.Data.Entities;


namespace school_Project.Core.Mapping.Instructorss
{
    public partial class InstructorProfile
    {
        public void AddInstructorCommandMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>()
                 .ForMember(dest => dest.Image, opt => opt.Ignore());

        }
    }
}
