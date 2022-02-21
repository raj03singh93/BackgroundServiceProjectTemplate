using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowServiceTemplateNET5.Common.Config;
using WindowServiceTemplateNET5.Repository.Extension;
using WindowServiceTemplateNET5.Service.Extension;

namespace WindowServiceTemplateNET5.Hosted.Extensions
{
    /// <summary>
    /// Application extention.
    /// </summary>
    public static class ServiceConfigureExtension
    {
        /// <summary>
        /// Configures all the dependencies.
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="configuration">configuration</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureWorkerAppService(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind appsettings to model.
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            services.AddAppRepository(configuration);
            services.AddAppService(configuration);
            services.AddLogging();
            return services;
        }
    }
}
