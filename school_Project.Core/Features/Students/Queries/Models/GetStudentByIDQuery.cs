using school_Project.Core.Bases;
using school_Project.Core.Features.Students.Queries.Dtos;
using MediatR;

namespace school_Project.Core.Features.Students.Queries.Models
{
    public class GetStudentByIDQuery : IRequest<Response<GetSingleStudent>>
    {
        public int Id { get; set; }

        public GetStudentByIDQuery(int id)
        {
            Id = id;
        }

    }
}
