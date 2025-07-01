using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.User.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.Authentication.Commands.Validator
{
    public class SignInValidator : AbstractValidator<AddUserCommand>
    {


        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public SignInValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public SignInValidator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.UserName).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);


            RuleFor(x => x.Password).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);


        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion

    }
}
