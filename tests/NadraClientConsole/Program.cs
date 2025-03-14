// See https://aka.ms/new-console-template for more information
using Axa.NadraClient.Nadra;
using Axa.NadraClient.Nadra.Models.OtcVerify;
using Axa.NadraClient.Nadra.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static async Task Main(string[] args)
    {
        // 1. Create a service collection
        var serviceCollection = new ServiceCollection();

        // 2. Configure services
        ConfigureServices(serviceCollection);

        // 3. Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // 4. Use the services
        var myService = serviceProvider.GetService<INadraService>();

        OtcVerifyFingerprintsRequest req = new OtcVerifyFingerprintsRequest {
            CustomerCnic = "3740519679619",
            CustomerMsisdn = "923215562042",
            FingerIndex = 1,
            AreaName = "PUNJAB",
            NadraTranId = "2005",
        };

        var cancellationToken = new CancellationToken();
        var nRes = await myService.OtcVerifyFingerprints(req, cancellationToken);



        Console.ReadLine();

    }
    private static void ConfigureServices(IServiceCollection services)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        // Register HttpClient
        services.AddHttpClient<NadraHttpClient>("NadraCllient", client =>
        {
            client.BaseAddress = new Uri(configuration["NadraConfiguration:BaseUrl"]);
        });



        // Register your service
        services.AddTransient<INadraService, NadraService>();
    }
}