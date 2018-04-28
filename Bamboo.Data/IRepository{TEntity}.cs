using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bamboo.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Add(TEntity entity);

        TEntity GetById(int Id);

        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] changedProperties);

        void Update(TEntity entity);

        void Delete(TEntity entity, bool isPhysicalDelete = false);

        void DeleteWhere(Expression<Func<TEntity, bool>> predicate, bool isPhysicalDelete = false);

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}
