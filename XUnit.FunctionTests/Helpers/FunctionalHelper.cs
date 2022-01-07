using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System;
using WindowServiceTemplateNET5.Hosted.Extensions;

namespace XUnit.FunctionTests.Helpers
{
    /// <summary>
    /// A helper class to generate all the dependencies.
    /// </summary>
    public class FunctionalHelper
    {
        private static IConfiguration configuration => GetConfiguration();

        /// <summary>
        /// Creates configuration from functional appsettings
        /// </summary>
        /// <returns></returns>
        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.FunctionTest.json", true, true)
                .Build();
        }
        /// <summary>
        /// Create all the dependencies.
        /// </summary>
        /// <returns> ServiceProvider</returns>
        public static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.ConfigureWorkerAppService(configuration);

            Logger logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddLogging(config => config.AddSerilog(logger));

            return services.BuildServiceProvider();
        }
    }
}
