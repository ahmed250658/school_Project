using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Instructors.Command.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Instructors.Command.Handler
{
    public class InstructorCommandHandler : ResponseHandler,
                                            IRequestHandler<AddInstructorCommand, Response<string>>


    {
        #region Fields
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public InstructorCommandHandler(IMapper mapper
                          , IStringLocalizer<SharedResource> stringLocalizer,
                            IInstructorService instructorService) : base(stringLocalizer)
        {

            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _instructorService = instructorService;
        }

        #endregion
        #region Function Handler
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            //Mapping
            var mapping = _mapper.Map<Instructor>(request);
            //Add Instructor
            var result = await _instructorService.AddInstructor(mapping, request.Image);
            switch (result)
            {
                case "NoImage": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.NoImage]);
                case "FailedToUpload": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.FailedToUpload]);
                case "FailedToAdd": return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.AddFaild]);
            }
            return Success<string>("");
        }
        #endregion

    }

}
