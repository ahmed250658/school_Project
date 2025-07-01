using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authentication.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Data.Helper;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                              IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
                                              IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>,
                                              IRequestHandler<SendResetPasswordCommand, Response<string>>,
                                              IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _singinManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructor
        public AuthenticationCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, UserManager<Users> userManager, SignInManager<Users> singinManager, IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _singinManager = singinManager;
            _authenticationService = authenticationService;
        }
        #endregion

        #region Handle Function
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if User is Exist or Not
            var user = await _userManager.FindByEmailAsync(request.Email);
            //Return User Not Found
            if (user == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.NotFound]);
            //Try Sign in
            var result = _singinManager.CheckPasswordSignInAsync(user, request.Password, false);
            //Confirm Email
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.ComfirmEmail]);
            if (!result.IsCompletedSuccessfully) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.PasswordIsNotExist]);
            //Generate Token
            var Result = await _authenticationService.GetJwtToken(user);
            return Success(Result);

        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwttoken = _authenticationService.ReadJwtToken(request.AcessToken);
            var userIdAndExpiredata = await _authenticationService.VaildateDetails(jwttoken, request.AcessToken, request.RefreshToken);
            switch (userIdAndExpiredata)
            {

                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.AlgorithmIsWrong]);
                case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.TokenisnotExpired]);
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.RefreshTokenIsNotFound]);
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedREsourceKeys.RefreshTokenistExpired]);
            }
            var (userId, expiredata) = userIdAndExpiredata;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }

            var result = await _authenticationService.GetRefreshToken(user, jwttoken, expiredata, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPassword(request.Email);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>();
                case "ErrorWhenUpdatingUser": return NotFound<string>(_stringLocalizer[SharedREsourceKeys.TryToRegisterAgain]);
                case "Failed": return NotFound<string>(_stringLocalizer[SharedREsourceKeys.TryAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>();
                case "Failed": return NotFound<string>(_stringLocalizer[SharedREsourceKeys.TryAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>();
            }
        }


        #endregion

    }
}
