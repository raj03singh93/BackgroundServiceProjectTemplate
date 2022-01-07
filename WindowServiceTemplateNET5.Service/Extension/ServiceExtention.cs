using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowServiceTemplateNET5.Service.Hosted;
using WindowServiceTemplateNET5.Service.Mapper;

namespace WindowServiceTemplateNET5.Service.Extension
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddHostedService<Worker>();
            return services;
        }
    }
}
