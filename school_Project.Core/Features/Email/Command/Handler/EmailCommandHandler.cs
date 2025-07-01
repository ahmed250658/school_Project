using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Email.Command.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Email.Command.Handler
{
    public class EmailCommandHandler : ResponseHandler,
                                         IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IEmailService _emailService;
        #endregion
        #region Constructor
        public EmailCommandHandler(IStudentService studentService, IMapper mapper
             , IStringLocalizer<SharedResource> stringLocalizer, IEmailService emailService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _emailService = emailService;
        }
        #endregion
        #region Function Handler
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)

        {
            var response = await _emailService.SendEmail(request.Email, request.Message, null);
            if (response == "Success")
                return Success<string>("");
            return BadRequest<string>(_stringLocalizer[SharedREsourceKeys.SendEmailFaild]);
        }
        #endregion
    }
}
