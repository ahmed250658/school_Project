using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authentication.Querys.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authentication.Querys.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                              IRequestHandler<AuthorizeUserQuery, Response<string>>,
                                              IRequestHandler<ConfirmEmailQuery, Response<string>>,
                                              IRequestHandler<ConfirmResetPasswordQuery, Response<string>>

    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructor
        public AuthenticationQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, UserManager<Users> userManager, SignInManager<Users> singinManager, IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
        }
        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.VaildateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>(_stringLocalizer[SharedREsourceKeys.TokenIsExpired]);
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.userId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.ErrorWhenConfirmEmail]);
            return Success<string>(_stringLocalizer[SharedREsourceKeys.ConfirmEmailDone]);
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmResetPassword(request.Code, request.Email);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>();
                case "Failed": return NotFound<string>(_stringLocalizer[SharedREsourceKeys.InvaildCode]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>();
            }
        }
        #endregion

    }
}
