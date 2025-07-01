using MediatR;
using school_Project.Core.Bases;
using school_Project.Data.Helper;

namespace school_Project.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
