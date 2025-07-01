using MediatR;
using school_Project.Core.Bases;
using school_Project.Core.Features.Department.Queries.Dtos;

namespace school_Project.Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentCount : IRequest<Response<List<GetDepartmentStudentCountResponse>>>
    {
    }
}
