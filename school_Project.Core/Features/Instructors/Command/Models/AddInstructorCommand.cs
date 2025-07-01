using MediatR;
using Microsoft.AspNetCore.Http;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Instructors.Command.Models
{
    public class AddInstructorCommand : IRequest<Response<string>>
    {
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public IFormFile? Image { get; set; }
        public int DID { get; set; }
    }
}
