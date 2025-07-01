using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using school_Project.Data.Helper;
using school_Project.Service.Abstracts;
using school_Project.Service.AuthService.Abstracts;
using school_Project.Service.AuthService.implementions;
using school_Project.Service.Impelementions;
using school_Project.Service.Implementations;

namespace school_Project.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<ConcurrentDictionary<string, RefreshToken>>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IFileService, FileService>();

            return services;
        }
    }
}
