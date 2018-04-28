using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(ICarouselRepository))]
    public class CarouselRepository : EntityRepository<CarouselEntity>, ICarouselRepository
    {
        public CarouselRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
