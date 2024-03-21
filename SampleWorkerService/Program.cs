using Microsoft.AspNetCore.Hosting;

namespace SampleWorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<Worker>();

            string connectionString = $"SERVER=xxx;DATABASE=xxx;UID=xxx;PASSWORD=xxx;";
            services.AddHealthChecks()
                    .AddMySql(connectionString)
                    .AddCheck<CustomHealthCheck>("custom_hc");

        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .Build();

        host.Run();
    }
}