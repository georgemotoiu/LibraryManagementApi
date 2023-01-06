using LibraryManagement.Application.Contracts.Services;
using LibraryManagement.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentsService, StudentsService>();

            return services;
        }
    }
}
