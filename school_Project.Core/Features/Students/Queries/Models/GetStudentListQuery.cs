using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Students.Queries.Dtos;

namespace school_Project.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
