using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.User.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
