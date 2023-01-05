using Library.Application.Contracts.Repositories;
using Library.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryManagementConnectionString")));

            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));            

            return services;
        }
    }
}
