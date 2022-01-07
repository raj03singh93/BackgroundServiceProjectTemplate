using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowServiceTemplateNET5.Repository.Extension;
using WindowServiceTemplateNET5.Service.Extension;

namespace WindowServiceTemplateNET5.Hosted.Extensions
{
    public static class ServiceConfigureExtension
    {
        public static IServiceCollection ConfigureWorkerAppService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppRepository(configuration);
            services.AddAppService(configuration);
            services.AddLogging();
            return services;
        }
    }
}
