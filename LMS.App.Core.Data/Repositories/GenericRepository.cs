﻿using LMS.App.Core.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal LMSContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(LMSContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
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
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
           dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        //public virtual void Update(TEntity entityToUpdate)
        //{
        //    dbSet.Attach(entityToUpdate);
        //    var roleEntry = context.UserRoles.SingleOrDefault(r => r.UserId == userRole.UserId);
        //    if (roleEntry != null)
        //    {
        //        context.UserRoles.Remove(roleEntry);
        //        SaveChanges();
        //    }
        //    context.Entry(entityToUpdate).State = EntityState.Modified;
        //}
        //public virtual void Update(TEntity entityToUpdate, TEntity entity2ToUpdate)
        //{
        //    dbSet.Attach(entityToUpdate);
        //    dbSet.Attach(entity2ToUpdate);
        //    context.Entry(entityToUpdate).State = EntityState.Modified;
        //    context.Entry(entity2ToUpdate).State = EntityState.Modified;
        //}
    }
}
