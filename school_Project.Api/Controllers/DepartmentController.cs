using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_Project.Api.Base;
using school_Project.Core.Features.Department.Queries.Models;
using school_Project.Data.AppMetaData;

namespace school_Project.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : AppBaseController
    {
        [HttpGet(Router.DepartmetnRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIDQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Router.DepartmetnRouting.GetViewDepartment)]
        public async Task<IActionResult> GetViewDepartmentStudentCount([FromQuery] GetDepartmentStudentCount query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Router.DepartmetnRouting.GetDepartmentStudentCountById)]
        public async Task<IActionResult> GetDepartmentStudentCountById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDepartmentStudentCountByIQuery() { DID = id });
            return NewResult(response);
        }
    }
}
