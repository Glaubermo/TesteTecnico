using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.API.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultMyTests")));

            return services;
        }
    }
}