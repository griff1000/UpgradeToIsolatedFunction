using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Net6InProcess;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Net6InProcess
{
    using FunctionCommon.Services;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMyService, MyService>();
        }
    }
}
