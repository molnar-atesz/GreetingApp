using GreetingApp.Terminal;
using GreetingApp.Terminal.Infrastructure;
using GreetingApp.Terminal.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

Log.Logger.Information("Application starting...");

var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IWriter, ConsoleWriter>();
                    services.AddScoped<DateTimeProvider, DateTimeProvider>();
                    services.AddTransient<GreetingService, GreetingService>();
                    services.AddTransient<GreetController>();
                })
                .UseSerilog()
                .Build();

var svc = ActivatorUtilities.CreateInstance<GreetController>(host.Services);
svc.Run();

static void BuildConfig(IConfigurationBuilder builder)
{
    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONTMENT");
    builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables();
}