using school_Project.Core.Features.User.Commands.Models;
using school_Project.Data.Entities.Identity;

namespace school_Project.Core.Mapping.User
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, Users>();
        }
    }
}
