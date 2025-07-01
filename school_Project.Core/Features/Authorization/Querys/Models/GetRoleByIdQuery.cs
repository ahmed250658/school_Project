using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Querys.Dtos;

namespace school_Project.Core.Features.Authorization.Querys.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleListResponse>>
    {
        public int Id { get; set; }
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
