using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable imp. of c#  garbage collector deleted after using it
            using (TContext ctx = new TContext())
            {
                var addedEntity = ctx.Entry(entity); //catch the referance
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var deletedEntity = ctx.Entry(entity); //catch the referance
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext ctx = new TContext())
            {
                return ctx.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext ctx = new TContext())
            {
                return filter == null
                    ? ctx.Set<TEntity>().ToList()
                    : ctx.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var updatedEntity = ctx.Entry(entity); //catch the referance
                updatedEntity.State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
