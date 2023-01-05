using System.Reflection;
using FluentValidation;
using Library.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
