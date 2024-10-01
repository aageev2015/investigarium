using HangfireBasicsServiceContract;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace HangfireBasicsService
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddHangfireBasicsService([NotNull] this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IHangfireBasicsService, HangfireBasicsServiceDefault>();

            return services;
        }
    }
}
