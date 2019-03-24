using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SuperHeroAPI.EntityFramework
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> expression = null);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);

        TEntity Add(TEntity entity);
         
        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);
    }
}
