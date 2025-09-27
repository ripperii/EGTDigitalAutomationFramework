using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Configs
{
    public static class FrameworkConfigProvider
    {
        private static FrameworkConfig? _config;

        public static FrameworkConfig Config => _config ??= LoadConfig();

        private static FrameworkConfig LoadConfig()
        {
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "dev";

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Configs", "appsettings.json"), optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Configs", $"appsettings.{environment}.json"), optional: true, reloadOnChange: true)
                .Build();

            return configuration.Get<FrameworkConfig>();
        }
    }
}
