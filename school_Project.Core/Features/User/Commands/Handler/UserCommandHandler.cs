using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.User.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities.Identity;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.User.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
                                            IRequestHandler<AddUserCommand, Response<string>>,
                                            IRequestHandler<EditUserCommand, Response<string>>,
                                            IRequestHandler<DeleteUserCommand, Response<string>>,
                                            IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly UserManager<Users> _userManager;
        private readonly IEmailService _emailsService;
        private readonly IUserService _userService;
        #endregion
        #region Constructor
        public UserCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, IMapper mapper, UserManager<Users> userManager, IUserService userService, IEmailService emailsService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _userService = userService;
            _emailsService = emailsService;
        }
        #endregion
        #region Handle Function
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //Mapping
            var identityUser = _mapper.Map<Users>(request);
            //Create
            var createResult = await _userService.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.EmailIsExist]);
                case "UserNameIsExist": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.UserNameIsExist]);
                case "ErrorInCreateUser": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.FaildAddUser]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.TryToRegisterAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createResult);
            }

        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (oldUser == null) return NotFound<string>();
            //mapping
            var newUser = _mapper.Map(request, oldUser);

            //if username is Exist
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            //username is Exist
            if (userByUserName != null) return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.IsExist]);

            //update
            var result = await _userManager.UpdateAsync(newUser);
            //result is not success
            if (!result.Succeeded) return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.UpdateFailed]);
            //message
            return Success((string)_stringLocalizer[SharedREsourceKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();
            //Delete the User
            var result = await _userManager.DeleteAsync(user);
            //in case of Failure
            if (!result.Succeeded) return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.DeleteFailed]);
            return Success((string)_stringLocalizer[SharedREsourceKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.Newpassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)_stringLocalizer[SharedREsourceKeys.Success]);
        }
        #endregion
    }
}
