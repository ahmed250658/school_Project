using school_Project.Core.Bases;
using school_Project.Data.Requests;
using MediatR;

namespace school_Project.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesResponse, IRequest<Response<string>>
    {


    }
}
