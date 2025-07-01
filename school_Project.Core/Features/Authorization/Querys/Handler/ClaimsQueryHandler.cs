using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Querys.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Requests;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Querys.Handler
{
    public class ClaimsQueryHandler : ResponseHandler,
                                   IRequestHandler<ManageUserClaimsQuery, Response<ManagerUserClaimsResponse>>


    {

        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly UserManager<Users> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClaimsQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, IMapper mapper, UserManager<Users> userManager, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        #endregion

        #region Handle Function

        public async Task<Response<ManagerUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            // get User
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManagerUserClaimsResponse>("");
            var result = await _authorizationService.GetManagerUserClaims(user);
            return Success(result);
        }
        #endregion

    }
}
