using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
