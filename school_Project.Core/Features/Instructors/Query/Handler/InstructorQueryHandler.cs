using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Instructors.Query.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Instructors.Query.Handler
{
    public class InstructorQueryHandler : ResponseHandler,
                                        IRequestHandler<GetSummationSalaryOfInstructorQuery, Response<decimal>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        #endregion
        #region Constructor
        public InstructorQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, IMapper mapper, IInstructorService instructorService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _instructorService = instructorService;
        }
        #endregion
        #region Function Handler
        public async Task<Response<decimal>> Handle(GetSummationSalaryOfInstructorQuery request, CancellationToken cancellationToken)
        {
            var result = await _instructorService.GetSalarySummationOfInstructor();
            return Success(result);
        }
        #endregion
    }
}
