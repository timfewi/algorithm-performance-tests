using Serilog;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

class Program
{

    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Setzt das aktuelle Verzeichnis als Basispfad
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();


        try
        {
            var host = CreateHostBuilder(args, configuration).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;


                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Starting application");
            }

            await host.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
    Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureServices((_, services) =>
        {
            // Services registration

        })
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddConfiguration(configuration);
        });

}