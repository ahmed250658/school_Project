using school_Project.Core.Features.Authorization.Querys.Dtos;
using school_Project.Data.Entities.Identity;

namespace school_Project.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<Role, GetRoleListResponse>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
