using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Department.Queries.Dtos;

namespace school_Project.Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIDQuery : IRequest<Response<GetDepartmentByIDQueryResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }


    }
}
