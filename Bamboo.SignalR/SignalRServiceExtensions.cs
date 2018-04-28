using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bamboo.SignalR
{
    public static class SignalRServiceExtensions
    {
        public static IServiceCollection AddSignalRService(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }
    }
}
