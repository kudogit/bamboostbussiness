using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyScanning(this IServiceCollection services)
        {
            services.AddSingleton<Scanner>();
            return services;
        }

        public static IServiceCollection ScanFromAssembly(this IServiceCollection services, AssemblyName assemblyName)
        {
            var scanner = services.GetScanner();
            scanner.RegisterAssembly(services, assemblyName);
            return services;
        }

        private static Scanner GetScanner(this IServiceCollection services)
        {
            var scanner = services.BuildServiceProvider().GetService<Scanner>();
            if (null == scanner)
            {
                throw new Exception("Unable to resolve Scanner. Did you forget to call services.AddDependencyScanning?");
            }
            return scanner;
        }
    }
}
