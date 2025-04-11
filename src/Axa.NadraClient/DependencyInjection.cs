using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniValidation;
using NadraClient.MiniValidation;
using NadraClient.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using NadraClient.MobileFingerVerification.Service.v1;
using NadraClient.DelegatingHandlers;

namespace NadraClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNadraClient(this IServiceCollection services)
        {
            services.AddOptions<NadraConfiguration>()
                .BindConfiguration(NadraConfiguration.SectionName)
                .ValidateMiniValidation()
                .ValidateOnStart();

            services.AddSingleton<INadraConfiguration>(sp => sp.GetRequiredService<IOptions<NadraConfiguration>>().Value);

            // Register NadraClient with optional custom handler
            services.AddTransient<LoggingHandler>();

            services.AddHttpClient<IMobileVerificationService, MobileFingerVerification.Service.v2.MobileVerificationService>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<NadraConfiguration>>().Value;
                client.BaseAddress = new Uri(options.MobileFingerConfig.BaseAddress);
            })
            .AddHttpMessageHandler<LoggingHandler>()
            .AddStandardResilienceHandler();

            return services;
        }
    }
}
