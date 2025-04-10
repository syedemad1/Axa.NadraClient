using Axa.NadraClient.Alt;
using Axa.NadraClient.Nadra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Shared
{
    public static class DependencyInjecion
    {
        public static IServiceCollection RegisterEwpServices(this IServiceCollection services)
        {
            // Get all types from the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Find all interfaces and their implementing classes
            var types = assembly.GetTypes();

            var registrations = types
                .Where(type => type.IsClass && !type.IsAbstract) // Find all non-abstract classes
                .Select(type => new
                {
                    Interface = type.GetInterfaces().FirstOrDefault(i => i.Name == "I" + type.Name), // Match interface by naming convention
                    Implementation = type
                })
                .Where(x => x.Interface != null); // Ensure there's a matching interface

            // Register each interface-implementation pair as Scoped
            foreach (var reg in registrations)
            {
                services.AddScoped(reg.Interface, reg.Implementation);
            }

            services.AddOptions<NadraConfiguration>()
               .BindConfiguration(NadraConfiguration.SectionName)
               .ValidateDataAnnotations()
               .ValidateOnStart();

            services.AddSingleton<NadraConfiguration>(sp => sp.GetRequiredService<IOptionsMonitor<NadraConfiguration>>().CurrentValue);

            // Register ALT
            services.AddOptions<AltConfiguration>()
               .BindConfiguration(AltConfiguration.SectionName)
               .ValidateDataAnnotations()
               .ValidateOnStart();

            services.AddSingleton<AltConfiguration>(sp => sp.GetRequiredService<IOptionsMonitor<AltConfiguration>>().CurrentValue);

            return services;
        }
    }
}
