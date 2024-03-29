using Serilog;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AlgorithmPerformanceTests.Helper;
using AlgorithmPerformanceTests.Services;
using AlgorithmPerformanceTests.Data;
using AlgorithmPerformanceTests.Algorithms.Sorting;

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
            ConsoleHelper.Logo();
            ConsoleHelper.Line();
            var host = CreateHostBuilder(args, configuration).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<Program>>();
                var performanceTester = services.GetRequiredService<PerformanceTester>();



                logger.LogInformation("Starting application");

                ConsoleHelper.Start();
                int[] data = DataGenerator.GenerateRandomArray(100000000, 0, 100000000);
                ConsoleHelper.Line();
                //performanceTester.TestSortAlgorithmWithValidation(Sorting.MergeSort, data);
                //ConsoleHelper.Message($"MergeSort abgeschloßen");
                //ConsoleHelper.Line();

                //performanceTester.TestSortAlgorithmWithValidation(Sorting.ParallelMergeSort, data);
                //ConsoleHelper.Message($"ParallelMergeSort abgeschloßen");
                //ConsoleHelper.Line();

                performanceTester.TestSortAlgorithmWithValidation(Sorting.QuickSort, data);
                ConsoleHelper.Message($"QuickSort abgeschlossen");
                ConsoleHelper.Line();

                //performanceTester.TestSortAlgorithmWithValidation(Sorting.InsertionSort, data);
                //ConsoleHelper.Message($"InsertionSort abgeschloßen");
                //ConsoleHelper.Line();


                ConsoleHelper.End();
            }

            await host.RunAsync();

            ConsoleHelper.Line();
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
            services.AddScoped<PerformanceTester>();
        })
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddConfiguration(configuration);
        });

}