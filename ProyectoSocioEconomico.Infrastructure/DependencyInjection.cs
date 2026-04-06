using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Infrastructure.Data;
using ProyectoSocioEconomico.Infrastructure.Services;

namespace ProyectoSocioEconomico.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString),
                optionsLifetime: ServiceLifetime.Singleton);
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICasoService, CasoService>();
            services.AddScoped<IProgramaService, ProgramaService>();
            services.AddScoped<IRetiroService, RetiroService>();

            return services;
        }
    }
}
