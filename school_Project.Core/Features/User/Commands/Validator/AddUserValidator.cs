using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.User.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.User.Commands.Validator
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public AddUserValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public AddUserValidator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.FullName).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.Address).
               NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.Email).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);
            RuleFor(x => x.Password).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);
            RuleFor(x => x.ConfirmPassword).
              Equal(x => x.Password).WithMessage(_stringLocalizer[SharedREsourceKeys.PasswordNotEquelConfrimPassword]);

        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion
    }
}
