﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EntityFramework
{
    public class EFBaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public EFBaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        //public IQueryable Entities => context.Set<TEntity>();

        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public TEntity GetByKey(object key)
        {
            return dbSet.Find(key);
        }

        public void Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            dbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            //dbSet.AddRange(entities);
            context.BulkInsert(entities);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "", int topNum = 0)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (topNum != 0)
            {
                return query.Take(topNum);
            }
            else
            {
                return query.ToList();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
