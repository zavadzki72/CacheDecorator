using Microsoft.Extensions.DependencyInjection;
using WebApi.Repositories;
using WebApi.Repositories.Caching;

namespace WebApi.Configurations {
    public static class InjectionConfiguration {

        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<ITeamRepository, TeamRepository>();
        }

        public static void AddDecorators(this IServiceCollection services) {
            services.AddScoped<TeamRepository>();
            services.AddScoped<ITeamRepository, TeamCachingDecorator<TeamRepository>>();
        }
    }
}
