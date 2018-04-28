using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bamboo.DependencyInjection.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Bamboo.DependencyInjection
{
    public class Scanner
    {
        public void RegisterAssembly(IServiceCollection services, AssemblyName assemblyName)
        {
            var folderFullPath = Path.GetFullPath(PlatformServices.Default.Application.ApplicationBasePath);;

            var listDllFileFullPath = Directory.GetFiles(folderFullPath, "*.dll").ToList();
            listDllFileFullPath.ForEach(path =>
            {
                RegisterPerAssembly(services, path);
            });
        }

        public void RegisterPerAssembly(IServiceCollection services, string path)
        {
            var assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var dependencyAttributes = type.GetCustomAttributes<DependencyAttribute>();
                foreach (var dependencyAttribute in dependencyAttributes)
                {
                    var serviceDescriptor = dependencyAttribute.BuildServiceDescriptor(type.GetTypeInfo());
                    services.Add(serviceDescriptor);
                }
            }
        }

    }
}
