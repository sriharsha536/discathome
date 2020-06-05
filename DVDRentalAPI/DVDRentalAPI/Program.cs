using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace DVDRentalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
                telemetryConfiguration.InstrumentationKey = "625dca7a-1fd9-4334-9d03-8666a2bed17f";

                Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole(
                        LogEventLevel.Verbose,
                        "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                .WriteTo.File(formatter: new CompactJsonFormatter(),
                              path: "Logs/myapp.txt",
                              retainedFileCountLimit: 10,
                              fileSizeLimitBytes: 123456,
                              rollingInterval: RollingInterval.Day)
                //.WriteTo.ApplicationInsights(telemetryConfiguration, TelemetryConverter.Traces)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
