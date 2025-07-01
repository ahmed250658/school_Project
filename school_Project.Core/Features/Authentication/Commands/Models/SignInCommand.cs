using MediatR;
using school_Project.Core.Bases;
using school_Project.Data.Helper;

namespace school_Project.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
