using AutoMapper;

namespace school_Project.Core.Mapping.User
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUserpaginationListMapping();
            GetUserByIdQuery();
            EditUserMapping();
        }
    }
}
