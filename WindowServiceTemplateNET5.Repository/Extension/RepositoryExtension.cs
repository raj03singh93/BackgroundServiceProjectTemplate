using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WindowServiceTemplateNET5.Repository.Extension
{
    /// <summary>
    /// Repository layer extention.
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
        /// Adds all repository layer dependencies.
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="configuration">configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddAppRepository(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
