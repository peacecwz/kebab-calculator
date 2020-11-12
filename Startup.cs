using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MLSA.Serverless.Services;

[assembly: FunctionsStartup(typeof(MLSA.Serverless.Startup))]
namespace MLSA.Serverless
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IKebapCalculatorService, KebapCalculatorService>();
        }
    }
}