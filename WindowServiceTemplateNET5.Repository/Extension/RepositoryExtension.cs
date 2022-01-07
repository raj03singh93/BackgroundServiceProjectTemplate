using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WindowServiceTemplateNET5.Repository.Extension
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddAppRepository(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
