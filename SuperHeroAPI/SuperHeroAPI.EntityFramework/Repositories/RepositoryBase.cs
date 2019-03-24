
using SuperHeroAPI.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        protected SuperHeroAPIContext context;
        protected DbSet<TEntity> dbSet;

        public RepositoryBase(SuperHeroAPIContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<TEntity>();
        }

        #region GET

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            return query.FirstOrDefault(expression);
        }

        #endregion

        #region GET ALL
        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {

            IQueryable<TEntity> query = dbSet;
 
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.ToList();

        }
 
        #endregion

        #region Persistencia

        public virtual TEntity Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;

            return entity;
        }

        
        public virtual TEntity Update(TEntity entity)
        {
           context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            context.Entry(entity).State =  EntityState.Deleted;
            return entity;
        }

        #endregion
    }
}