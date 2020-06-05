using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace DVDRentalAPI.Helpers.Extensions
{
    public static class ConfigurationHelper
    {

        public static IConfigurationRoot GetConfiguration([Optional] IConfiguration configuration, string userSecretsKey = null)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(envName))
                builder.AddJsonFile($"appsettings.{envName}.json", optional: true);

            //if (!string.IsNullOrWhiteSpace(userSecretsKey))
            //    builder.AddUserSecrets(userSecretsKey);

            builder.AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
