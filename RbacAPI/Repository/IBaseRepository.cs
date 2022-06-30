using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseRepository<TEntity, TKey>where TEntity : class where TKey : struct
    {
        int AddAll(List<TEntity> t);
        int AddInfo(TEntity t);
        int Deletelame(Expression<Func<TEntity, bool>> predicate);
        int Delete(TKey id);
        TEntity GetBity(TKey key);
        TEntity GetEntity(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate=null);
        List<TEntity> QueryAll();
        int UpdInfo(TEntity t);
    }
}