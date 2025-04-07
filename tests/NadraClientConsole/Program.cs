// See https://aka.ms/new-console-template for more information
using Axa.NadraClient.Nadra;
using Axa.NadraClient.Nadra.Models.OtcVerify;
using Axa.NadraClient.Nadra.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

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

        if (myService != null)
        {
            try
            {
                OtcVerifyFingerprintsRequest req = new OtcVerifyFingerprintsRequest("Magicbox", "BN-101", "1234567890123", "03001234567", "1234567890123", "03001234567", 1, "fingerTemplate", TemplateTypes.ANSI, null, 1000, RemittanceTypes.MONENY_TRANSFER_SEND, "PUNJAB", null, null);

                Console.WriteLine(JsonSerializer.Serialize(req));

                var cancellationToken = new CancellationToken();
                var nRes = await myService.OtcVerifyFingerprints(req, cancellationToken);
                if (nRes.IsSuccess)
                {
                    Console.WriteLine(JsonSerializer.Serialize(nRes.Value));
                }
                else
                {
                    Console.WriteLine($"Error: {JsonSerializer.Serialize(nRes)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

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
