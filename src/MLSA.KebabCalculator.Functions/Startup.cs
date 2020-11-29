using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MLSA.KebabCalculator.Functions;
using MLSA.KebabCalculator.Functions.HealthRules;
using MLSA.KebabCalculator.Functions.Services;

[assembly: FunctionsStartup(typeof(Startup))]

namespace MLSA.KebabCalculator.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMvcCore().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddSingleton<IHealthRulesChain, HealthRulesChain>();
            builder.Services.AddSingleton<IKebabServices, KebabServices>();
        }
    }
}