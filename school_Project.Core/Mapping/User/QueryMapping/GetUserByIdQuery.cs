using school_Project.Core.Features.User.Querys.Dtos;
using school_Project.Data.Entities.Identity;

namespace school_Project.Core.Mapping.User
{
    public partial class UserProfile
    {
        public void GetUserByIdQuery()
        {
            CreateMap<Users, GetUserByIdQueryResponse>().
                ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName)).
                ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
                ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).
                ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
        }
    }
}
