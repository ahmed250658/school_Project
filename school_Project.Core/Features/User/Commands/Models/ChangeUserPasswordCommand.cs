using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.User.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string Newpassword { get; set; }
        public string Confrimpassword { get; set; }
    }
}
