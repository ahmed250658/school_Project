using MediatR;
using school_Project.Core.Bases;
using school_Project.Data.Requests;

namespace school_Project.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
