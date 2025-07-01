using Microsoft.Extensions.DependencyInjection;
using school_Project.Data.Entities.Views;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Repository.Abstract;
using school_Project.Infrastructure.Repository.Abstract.Abstractproc;
using school_Project.Infrastructure.Repository.Abstract.AbstractView;
using school_Project.Infrastructure.Repository.Abstract.Function;
using school_Project.Infrastructure.Repository.Impelement;
using school_Project.Infrastructure.Repository.Impelement.Function;
using school_Project.Infrastructure.Repository.Impelement.ImpelementProc;
using school_Project.Infrastructure.Repository.Impelement.ImpelemetView;

namespace school_Project.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IStrudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            //View
            services.AddTransient<IViewReporsitory<ViewDepartment>, ViewDepartmentReporsitory>();
            //Procedure
            services.AddTransient<IDepartmentProcRepository, DepartmentProcRepository>();
            //Function
            services.AddTransient<IInstructorFunctionsRepository, InstructorFunctionsRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }

    }
}
