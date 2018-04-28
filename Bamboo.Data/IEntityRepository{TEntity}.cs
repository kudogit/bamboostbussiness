using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data
{
    public interface IEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
