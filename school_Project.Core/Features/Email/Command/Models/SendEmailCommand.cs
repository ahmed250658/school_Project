using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Email.Command.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
