using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.User.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.User.Commands.Validator
{
    public class ChangeUserPasswordVaildator : AbstractValidator<ChangeUserPasswordCommand>
    {

        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public ChangeUserPasswordVaildator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public ChangeUserPasswordVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Id).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

            RuleFor(x => x.CurrentPassword).
               NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

            RuleFor(x => x.Newpassword).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);
            RuleFor(x => x.Confrimpassword).
              Equal(x => x.Newpassword).WithMessage(_stringLocalizer[SharedREsourceKeys.PasswordNotEquelConfrimPassword]);

        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion
    }
}
