using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroAPI.EntityFramework
{
    public interface IServices<TEntity> where TEntity : class
    {
        QuerySet GetQuerySet();

        TEntity Get(int id);

        List<TEntity> GetAll();

        TEntity Create(TEntity Entity);

        TEntity Update(TEntity Entity);

        TEntity Remove(int id);
    }
}
