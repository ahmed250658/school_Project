using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Department.Queries.Dtos;

namespace school_Project.Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentCountByIQuery : IRequest<Response<GetDepartmentStudentCountByIQueryReposne>>
    {
        public int DID { get; set; }
    }
}
