using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.Instructors.Command.Models;
using school_Project.Core.Features.Instructors.Query.Models;
using school_Project.Data.AppMetaData;

namespace school_Project.Api.Controllers
{

    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class InstructorController : AppBaseController
    {
        [HttpGet(Router.Instructor.GetSalarySummationOfInstructor)]
        public async Task<IActionResult> GetSalarySummation()
        {
            return NewResult(await Mediator.Send(new GetSummationSalaryOfInstructorQuery()));
        }
        [HttpPost(Router.Instructor.Create)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
