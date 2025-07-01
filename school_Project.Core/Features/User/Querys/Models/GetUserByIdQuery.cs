using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.User.Querys.Dtos;

namespace school_Project.Core.Features.User.Querys.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdQueryResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
