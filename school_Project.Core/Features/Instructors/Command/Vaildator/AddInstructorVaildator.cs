using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Instructors.Command.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Instructors.Command.Vaildator
{
    public class AddInstructorVaildator : AbstractValidator<AddInstructorCommand>
    {
        #region Fields
        private readonly IInstructorService _InstructorService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IDepartmentService _departmentService;

        #endregion
        #region Constructors
        public AddInstructorVaildator(IStringLocalizer<SharedResource> stringLocalizer, IDepartmentService departmentService, IInstructorService instructorService)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _InstructorService = instructorService;
        }
        public AddInstructorVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }
        #endregion
        #region Actions
        public void ApplyValidationRoles()
        {
            RuleFor(x => x.ENameAr).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);


            RuleFor(x => x.ENameEn).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.Address).
               NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.DID).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

        }
        public void ApplyCustomValidationRoles()
        {
            RuleFor(x => x.ENameAr)
                .MustAsync(async (key, CollectionToken) => !await _InstructorService.IsNameArExist(key))
                .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
            RuleFor(x => x.ENameEn)
               .MustAsync(async (key, CollectionToken) => !await _InstructorService.IsNameEnExist(key))
               .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
            RuleFor(x => x.DID)
              .MustAsync(async (key, CollectionToken) => await _departmentService.IsDepartmentIdExist(key))
              .WithMessage(_stringLocalizer[SharedREsourceKeys.DepartmentIdNotIsExist]);

        }
        #endregion

    }
}
