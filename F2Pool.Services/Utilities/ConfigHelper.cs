using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace HashRates.Utilities
{
    public static class ConfigHelper
    {
        public static string GetAppSetting(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            var config = builder.Build();

            return config[key] ?? "";
        }
    }
}
