using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.Email.Command.Models;
using school_Project.Data.AppMetaData;

namespace school_Project.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class EmailController : AppBaseController
    {
        [HttpPost(Router.Email.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
