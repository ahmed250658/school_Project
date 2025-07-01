using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Authentication.Querys.Models
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public int userId { get; set; }
        public string Code { get; set; }
    }
}
