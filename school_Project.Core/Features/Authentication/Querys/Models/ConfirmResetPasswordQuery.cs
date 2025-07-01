using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Authentication.Querys.Models
{
    public class ConfirmResetPasswordQuery : IRequest<Response<string>>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
