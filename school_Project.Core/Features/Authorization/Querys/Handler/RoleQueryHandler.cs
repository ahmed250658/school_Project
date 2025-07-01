using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Querys.Dtos;
using school_Project.Core.Features.Authorization.Querys.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Requests;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Querys.Handler
{
    public class RoleQueryHandler : ResponseHandler,
                                   IRequestHandler<GetRoleListQuery, Response<List<GetRoleListResponse>>>,
                                   IRequestHandler<GetRoleByIdQuery, Response<GetRoleListResponse>>,
                                   IRequestHandler<ManagerUserRolesQuery, Response<ManagerUserRolesResponse>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public RoleQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, IMapper mapper, IAuthorizationService authorizationService, UserManager<Users> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        #endregion

        #region Handle Function
        public async Task<Response<List<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRoleListResponse>>(roles);
            return Success(result);
        }

        public async Task<Response<GetRoleListResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRoleById(request.Id);
            if (roles == null) return NotFound<GetRoleListResponse>(_stringLocalizer[SharedREsourceKeys.RoleIsNotExist]);
            var result = _mapper.Map<GetRoleListResponse>(roles);
            return Success(result);
        }

        public async Task<Response<ManagerUserRolesResponse>> Handle(ManagerUserRolesQuery request, CancellationToken cancellationToken)
        {
            // get User
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManagerUserRolesResponse>("");
            var result = await _authorizationService.GetManagerUserRoles(user);
            return Success(result);
        }
        #endregion
    }
}
