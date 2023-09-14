using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XRPL.NET.Configs;

namespace XRPL.NET;

public static class XrplClientStartup
{
    public static IServiceCollection AddXrplClient(this IServiceCollection services, IConfiguration config)
    {
        var section = config.GetSection(XrplClientConfig.SectionKey);
        if (!section.Exists())
        {
            throw new Exception($"Failed to find configuration section with key '{XrplClientConfig.SectionKey}'");
        }

        services.Configure<XrplClientConfig>(section);
        services.AddSingleton<IXrplClient, XrplClient>();

        return services;
    }
}
