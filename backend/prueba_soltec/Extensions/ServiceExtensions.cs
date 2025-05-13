using prueba_soltec.Interfaces;
using prueba_soltec.Repositories;
using prueba_soltec.Services;

namespace prueba_soltec.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuariosRepository>();
            return services;
        }
        public static IServiceCollection AddAllDependencies(this IServiceCollection services)
        {
            services
                .AddAplicationService()
                .AddRepositories();
            return services;
        }
    }
}
