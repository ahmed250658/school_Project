using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Authorization.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Commands.Handler
{
    public class RoleCommandHandler : ResponseHandler,
                                      IRequestHandler<AddRoleCommand, Response<string>>,
                                      IRequestHandler<EditRoleCommand, Response<string>>,
                                      IRequestHandler<DeleteRoleCommand, Response<string>>,
                                      IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion

        #region Constructor
        public RoleCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, RoleManager<Role> roleManager, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }
        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Success") return Success("");
            return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.AddFaild]);
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Success") return Success<string>((string)_stringLocalizer[SharedREsourceKeys.Updated]);
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Used") return BadRequest<string>((string)_stringLocalizer[SharedREsourceKeys.RoleIsUsed]);
            else if (result == "Success") return Success<string>((string)_stringLocalizer[SharedREsourceKeys.Updated]);
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case ("UserIsNull"): return NotFound<string>();
                case ("FailedToRemoveOldRoles"): return BadRequest<string>((string)_stringLocalizer[SharedREsourceKeys.FaildRemoveOldRole]);
                case ("FailedToAddNewRoles"): return BadRequest<string>((string)_stringLocalizer[SharedREsourceKeys.FaildAddNewRole]);
                case ("FailedToAddRoles"): return BadRequest<string>((string)_stringLocalizer[SharedREsourceKeys.AddFaild]);
            }
            return Success<string>(_stringLocalizer[SharedREsourceKeys.Success]);
        }
        #endregion

    }
}
