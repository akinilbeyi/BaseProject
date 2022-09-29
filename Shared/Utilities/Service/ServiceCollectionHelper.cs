using Microsoft.Extensions.DependencyInjection;

namespace Shared.Utilities.Service;
public static class IoCHelper
{
    public static IServiceProvider? ServiceProvider { get; set; }
    public static void Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
    }
}
