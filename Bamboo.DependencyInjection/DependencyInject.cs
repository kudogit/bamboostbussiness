using Bamboo.Data.EF.Repositories.File;
using Bamboo.Data.File;
using Bamboo.Service.Auth;
using Bamboo.Service.Facade.Auth;
using Microsoft.Extensions.DependencyInjection;
using System;
using Bamboo.Data.EF.Repositories;
using Bamboo.Data.IRepositories;
using Bamboo.Service;
using Bamboo.Service.Facade;
using Bamboo.Util;

namespace Bamboo.DependencyInjection
{
    public class DependencyInject
    {
        private static IServiceCollection _services;

        public DependencyInject(IServiceCollection services)
        {
            _services = services;
        }

        public void RepositoryInject()
        {
            _services.AddTransient<IFileRepository, FileRepository>();
            _services.AddTransient<ICarouselRepository, CarouselRepository>();
        }

        public void ServicesInject()
        {
            _services.AddTransient<IAuthService, AuthService>();
            _services.AddTransient<ICarouselService, CarouselService>();
            _services.AddTransient(typeof(ConfigSettings));
        }
    }
}
