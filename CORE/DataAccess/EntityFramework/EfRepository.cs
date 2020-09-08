using CORE.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AdminPanelCore.CORE.DataAccess.EntityFramework
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<TEntity, TResult>> select)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Select(select);
            }
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> select)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Select(select).Cast<TResult>();
            }
        }

        public bool Delete(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().RemoveRange(GetList(filter));
                return context.SaveChanges() > 0;
            }
        }

        public decimal Max(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, decimal>> column)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Max(column);
            }
        }

        public decimal Min(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, decimal>> column)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Min(column);
            }
        }

        public int? Max(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Nullable<int>>> column)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Max(column);
            }
        }

        public int? Min(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Nullable<int>>> column)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Min(column);
            }
        }

        public decimal Sum(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, decimal>> column)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Sum(column);
            }
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Count();
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Any();
            }
        }
    }
}