using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.DependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class DependencyAttribute : Attribute
    {
        public ServiceLifetime DependencyType { get; }
        protected DependencyAttribute(ServiceLifetime dependencyType)
        {
            DependencyType = dependencyType;
        }

        public Type ServiceType { get; set; }

        public ServiceDescriptor BuildServiceDescriptor(TypeInfo type)
        {
            var serviceType = ServiceType ?? type.AsType();

            return new ServiceDescriptor(serviceType, type.AsType(), DependencyType);
        }
    }

    public class ScopeDependencyAttribute : DependencyAttribute
    {
        public ScopeDependencyAttribute() : base(ServiceLifetime.Scoped)
        {
        }
    }

    public class SingletonDependencyAttribute : DependencyAttribute
    {
        public SingletonDependencyAttribute() : base(ServiceLifetime.Singleton)
        {
        }
    }

    public class TransientDependencyAttribute : DependencyAttribute
    {
        public TransientDependencyAttribute() : base(ServiceLifetime.Transient)
        {
        }
    }
}
