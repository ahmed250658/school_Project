using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.Students.Commands.Models;
using school_Project.Core.Features.Students.Queries.Models;
using school_Project.Data.AppMetaData;


namespace school_Project.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class StudentController : AppBaseController
    {
        #region Handle Functions

        [HttpGet(Router.StudentRouting.list)]
        // [Authorize(Roles = "User")]
        //[ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPagenatedQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
        #endregion
    }
}
