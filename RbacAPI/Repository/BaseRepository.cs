﻿using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<TEntity, Key> : IBaseRepository<TEntity, Key> where TEntity : class where Key : struct
    {

        protected MyDbContext myDbContext;

        public virtual int AddInfo(TEntity t)
        {
            myDbContext.Set<TEntity>().Add(t);
            return myDbContext.SaveChanges();
        }

        public virtual int AddAll(List<TEntity> t)
        {
            foreach (var item in t)
            {
                myDbContext.Set<TEntity>().Add(item);
            }
            return myDbContext.SaveChanges();
        }

        public int UpdInfo(TEntity t)
        {
            myDbContext.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return myDbContext.SaveChanges();
        }

        public TEntity GetBity(Key key)
        {
            var list = myDbContext.Set<TEntity>().Find(key);
            return list;
        }

        public int Delete(Key id)
        {
            var list = myDbContext.Set<TEntity>().Find(id);
            myDbContext.Remove(list);
            return myDbContext.SaveChanges();
        }

        public int Deletelame(Expression<Func<TEntity, bool>> predicate)
        {
            var list = myDbContext.Set<TEntity>().Where(predicate);
            myDbContext.Remove(list);
            return myDbContext.SaveChanges();
        }


        public List<TEntity> QueryAll()
        {
            var list = myDbContext.Set<TEntity>().ToList();
            return list;
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            var list = myDbContext.Set<TEntity>();
            return list;
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return myDbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return myDbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
    }
}
