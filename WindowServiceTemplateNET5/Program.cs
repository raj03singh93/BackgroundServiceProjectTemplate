using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using WindowServiceTemplateNET5.Hosted.Extensions;

namespace WindowServiceTemplateNET5.Hosteds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configBuilder) => 
                {
                    string env = Environment.GetEnvironmentVariable("");

                    var mainModule = Process.GetCurrentProcess().MainModule;
                    if (mainModule != null)
                    {
                        string pathToExe = mainModule.FileName;
                        string pathToDirectory = Path.GetDirectoryName(pathToExe);
                        Directory.SetCurrentDirectory(pathToDirectory);
                    }

                    configBuilder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .AddJsonFile($"appsettings.{env}.json", true, true)
                    .AddCommandLine(args)
                    .AddEnvironmentVariables();
                })
                .UseSerilog((hostContext, config) => config.ReadFrom.Configuration(hostContext.Configuration))
                .ConfigureServices((hostContext, services) =>
                {
                    services.ConfigureWorkerAppService(hostContext.Configuration);
                })
                .UseWindowsService();
    }
}
