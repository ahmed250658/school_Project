using MediatR;
using school_Project.Core.Features.Students.Queries.Dtos;
using school_Project.Core.Pagination;
using school_Project.Data.Enums;

namespace school_Project.Core.Features.Students.Queries.Models
{
    public class GetStudentPagenatedQuery : IRequest<PaginatedResult<GetStudentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
