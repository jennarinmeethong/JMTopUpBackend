global using JMTopUpBackend.Application;
global using JMTopUpBackend.Application.Services;
global using JMTopUpBackend.Domain;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.IdentityModel.Tokens;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient(typeof(Lazy<>), typeof(Lazier<>));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICryptographyService, CryptographyService>();
            return services;
        }
    }
}
