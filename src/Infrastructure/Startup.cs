global using JMTopUpBackend.Application;
global using JMTopUpBackend.Infrastructure.Contexts;
global using JMTopUpBackend.Infrastructure.Repositories;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<JMTopUpContext>(oa => oa.UseSqlServer(configuration.GetConnectionString("JMTopUpDatabase")));
            services.AddTransient<ICoreRepository, CoreRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            return services;
        }
    }
}
