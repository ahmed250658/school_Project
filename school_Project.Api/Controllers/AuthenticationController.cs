using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.Authentication.Commands.Models;
using school_Project.Core.Features.Authentication.Querys.Models;
using school_Project.Data.AppMetaData;

namespace school_Project.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppBaseController
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> CreateUser([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.VaildateToken)]
        public async Task<IActionResult> VaildateToken([FromQuery] AuthorizeUserQuery Query)
        {
            var response = await Mediator.Send(Query);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery Query)
        {
            var response = await Mediator.Send(Query);
            return NewResult(response);
        }
        [HttpPost(Router.Authentication.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.Authentication.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery Query)
        {
            var response = await Mediator.Send(Query);
            return NewResult(response);
        }
        [HttpPost(Router.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
