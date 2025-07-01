using MediatR;
using school_Project.Core.Bases;
using school_Project.Data.Requests;

namespace school_Project.Core.Features.Authorization.Querys.Models
{
    public class ManagerUserRolesQuery : IRequest<Response<ManagerUserRolesResponse>>
    {
        public int UserId { get; set; }
    }
}
