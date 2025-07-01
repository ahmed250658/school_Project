using MediatR;
using school_Project.Core.Features.User.Querys.Dtos;
using school_Project.Core.Pagination;

namespace school_Project.Core.Features.User.Querys.Models
{
    public class GetUserListQuery : IRequest<PaginatedResult<GetUserListQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
