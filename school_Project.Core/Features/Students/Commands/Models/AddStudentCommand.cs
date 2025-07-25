﻿using MediatR;
using school_Project.Core.Bases;

namespace school_Project.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string? phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
