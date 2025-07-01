using AutoMapper;
using school_Project.Core.Bases;
using school_Project.Core.Features.User.Querys.Dtos;
using school_Project.Core.Features.User.Querys.Models;
using school_Project.Core.Pagination;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace school_Project.Core.Features.User.Querys.Handler
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListQueryResponse>>,
                                                 IRequestHandler<GetUserByIdQuery, Response<GetUserByIdQueryResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly UserManager<Users> _userManager;
        #endregion
        #region Constructor
        public UserQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, UserManager<Users> userManager, IMapper mapper) : base(stringLocalizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handler Function 
        public async Task<Response<GetUserByIdQueryResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<GetUserByIdQueryResponse>(_stringLocalizer[SharedREsourceKeys.NotFound]);
            var reslut = _mapper.Map<GetUserByIdQueryResponse>(user);
            return Success(reslut);
        }

        async Task<PaginatedResult<GetUserListQueryResponse>> IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListQueryResponse>>.Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserListQueryResponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
        #endregion
    }
}
