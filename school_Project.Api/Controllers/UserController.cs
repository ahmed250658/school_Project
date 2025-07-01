using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.User.Commands.Models;
using school_Project.Core.Features.User.Querys.Models;
using school_Project.Data.AppMetaData;

namespace school_Project.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class UserController : AppBaseController
    {
        [HttpPost(Router.AppUserRouting.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AppUserRouting.Paginated)]
        public async Task<IActionResult> PaginatedListOfUser([FromQuery] GetUserListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.AppUserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
        [HttpPut(Router.AppUserRouting.Edit)]
        public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }
        [HttpPut(Router.AppUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }
        [HttpDelete(Router.AppUserRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
    }
}
