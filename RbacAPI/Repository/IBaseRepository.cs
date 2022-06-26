using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseRepository<TEntity, Key>where TEntity : class where Key : struct
    {
        int AddAll(List<TEntity> t);
        int AddInfo(TEntity t);
        int Deletelame(Expression<Func<TEntity, bool>> predicate);
        int Delete(Key id);
        TEntity GetBity(Key key);
        TEntity GetEntity(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> QueryAll();
        int UpdInfo(TEntity t);
    }
}