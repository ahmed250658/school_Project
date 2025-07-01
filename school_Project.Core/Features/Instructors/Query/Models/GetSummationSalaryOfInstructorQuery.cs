using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Instructors.Query.Models
{
    public class GetSummationSalaryOfInstructorQuery : IRequest<Response<decimal>>
    {
    }
}
