using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.NetCore.Data.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Services;
using TesteTecnico.NetCore.Domain.Services;

namespace TesteTecnico.NetCore.API.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services,
                                                                          IConfiguration configuration)
        {

            /* Domain => Repository */
            services.AddScoped<IHistoricoEscolarRepository, HistoricoEscolarRepository>();
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            /* Domain => Service */
            services.AddScoped<IHistoricoEscolarDomainService, HistoricoEscolarDomainService>();
            services.AddScoped<IEscolaridadeDomainService, EscolaridadeDomainService>();
            services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();



            return services;
        }
    }
}
