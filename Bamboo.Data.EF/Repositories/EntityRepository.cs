using Bamboo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Repositories
{
    public class EntityRepository<TEntity> : Repository<DbContext, TEntity>, IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        public EntityRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
