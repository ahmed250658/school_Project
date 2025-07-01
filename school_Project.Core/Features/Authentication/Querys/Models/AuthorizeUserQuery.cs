using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Authentication.Querys.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
