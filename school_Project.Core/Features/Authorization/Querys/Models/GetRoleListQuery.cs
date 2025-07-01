using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Querys.Dtos;

namespace school_Project.Core.Features.Authorization.Querys.Models
{
    public class GetRoleListQuery : IRequest<Response<List<GetRoleListResponse>>>
    {
    }
}
