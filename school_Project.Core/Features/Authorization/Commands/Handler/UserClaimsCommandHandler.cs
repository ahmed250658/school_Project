using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Commands.Handler
{
    public class UserClaimsCommandHandler : ResponseHandler,
                                          IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion
        #region Constructor
        public UserClaimsCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }
        #endregion
        #region Handler Function
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case ("UserIsNull"): return NotFound<string>();
                case ("FailedToRemoveOldClaims"): return BadRequest<string>();
                case ("FailedToAddNewClaims"): return BadRequest<string>();
                case ("FailedToUpdateClaims"): return BadRequest<string>();
            }
            return Success<string>(_stringLocalizer[SharedREsourceKeys.Success]);
        }
        #endregion

    }
}
