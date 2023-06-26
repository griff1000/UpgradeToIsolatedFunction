using FunctionCommon.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(ConfigureServices)
    .Build();

host.Run();

void ConfigureServices(HostBuilderContext context, IServiceCollection collection)
{
    collection.AddSingleton<IMyService, MyService>();
}


