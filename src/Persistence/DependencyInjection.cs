using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oncologia.Application.Common.Interfaces;

namespace Oncologia.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OncologiaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OncologiaDatabase")));

            services.AddScoped<IOncologiaDbContext>(provider => provider.GetService<OncologiaDbContext>());

            return services;
        }
    }
}
